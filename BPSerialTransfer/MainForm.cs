/*
 * Created by Francis Studios.
 * User: Vendéghegyi Levente
 * Date: 2020. 11. 28.
 * Time: 10:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace BPSerialTransfer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public bool devicePaired = false;
		public string comPort;
		public int bauds;
		
		public SerialPort CreateSerialPort(string comPort, int bauds){
			
			string[] availablePorts = SerialPort.GetPortNames();
			string doesItContains = "nope";
			
			foreach (string onePort in availablePorts)
			{
				if(onePort.Equals(comPort)){
					doesItContains = "yap";
				}
			}
						
			if(doesItContains.Equals("yap"))
			{
				SerialPort port = new SerialPort(comPort, bauds, Parity.None, 8, StopBits.One);
				return port;
			}else{
				consoleBox.AppendText(String.Format("[ ERROR ] UNABLE TO BIND PORT {0} \n", comPort));
				string[] avPrt = SerialPort.GetPortNames();
				SerialPort camoufflagePort = new SerialPort(avPrt[0], 1997, Parity.Odd, 8, StopBits.One);
				return camoufflagePort;
			}
		}
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		void startDownload(object sender, EventArgs e)
		{
			if(devicePaired == false){
				consoleBox.AppendText("Getting COM-PORT status...\n");
				comPort = comName.Text;
				string[] portsN = SerialPort.GetPortNames();
				int portsn = portsN.Length;
				
				if(!String.IsNullOrEmpty(comPort) && portsn > 0){
					bauds = Convert.ToInt32(Math.Round(baudRate.Value, 0));
					if(bauds > 0){
						consoleBox.AppendText(String.Format("< {0} > communication...\n", comPort));
						consoleBox.AppendText(String.Format("Polling BPS @ {0} bauds \n", bauds));
						
						txLED.ForeColor = Color.Red;
						SerialPort port = CreateSerialPort(comPort, bauds);
						txLED.ForeColor = Color.Black;
						
						if(port.BaudRate == 1997){
							return;
						}
						
						port.ReadTimeout = 5000;
						rxLED.ForeColor = Color.Red;
						port.Open();
						rxLED.ForeColor = Color.Black;
						bool polling = true;
						
						while(true){
							
							if(polling == true){
								txLED.ForeColor = Color.Red;
								port.WriteLine("b9p538s3");
								txLED.ForeColor = Color.Black;
								consoleBox.AppendText("Sending pairing attempt to BPS \n");
								polling = false;
							}
							string serialInput;
							try{
								rxLED.ForeColor = Color.Red;
								serialInput = port.ReadLine();
								rxLED.ForeColor = Color.Black;
							}catch{
								consoleBox.AppendText("[ TIMEOUT ] timeout error occured!");
								break;
							}
							string[] receivedMessage = serialInput.Split(':');
							if(receivedMessage.Length >= 2){
								string serialDeviceID = receivedMessage[0];
								string serialMessage = receivedMessage[1];
							
								if(serialDeviceID == "0xb00a8"){
									//consoleBox.AppendText(String.Format("Received [] bytes from {0} > {1} \n", serialDeviceID, serialMessage));
									serialMessage.Trim();
									string cleansedMessage = serialMessage.Replace("\n", "").Replace("\r", "");
									
									if(cleansedMessage.Equals("brb9600bps")){
										devicePaired = true;
										port.WriteLine("bsp09128n2");
										break;
									}else{
										consoleBox.AppendText("[ WARNING ] Pairing attempt failed! \n");	
									}
								}
								
							}
						}
						
						if(devicePaired){
							consoleBox.AppendText("< 0xb00a8 > BPSandal PAIRED SUCCESFULLY");
							statusLED.ForeColor = Color.Lime;
							statusLED.Text = "ONLINE";
							downloadButton.Text = "Download";
							
							port.Close();
						}
						
					}else{
						consoleBox.AppendText("[ ERROR ] Baud rate must be specified! \n");
					}
					
				}else{
					consoleBox.AppendText("[ ERROR ] Port not specified! \n");
				}
			}else{
				string[] portsN = SerialPort.GetPortNames();
				int portsn = portsN.Length;
				
				if(devicePaired == true && portsn > 0){
					consoleBox.Clear();
					consoleBox.AppendText("Attempting download from 0xb00a8... \n");
					
					SerialPort port = CreateSerialPort(comPort, bauds);
					port.ReadTimeout = 10000;
					port.Open();
					
					txLED.ForeColor = Color.Red;
					port.WriteLine("d4v41t0v0r15c1");
					consoleBox.AppendText("[ INFO ] Downstream request sent to BPS \n");
					txLED.ForeColor = Color.Black;
					bool responseBL = true;
					
					while(responseBL){
						string response;
						try{
							rxLED.ForeColor = Color.Red;
							response = port.ReadLine();
							consoleBox.AppendText(response+"\n");
							rxLED.ForeColor = Color.Black;
						}catch{
							rxLED.ForeColor = Color.Black;
							consoleBox.AppendText("[ TIMEOUT ] timeout error occured!");
							break;
						}
						string[] responseA = response.Split(':');
						if(responseA.Length >= 2){
							string responseDeviceID = responseA[0];
							string responseMessage = responseA[1];
							
							response.Trim();
							string cleansedResponse = responseMessage.Replace("\n", "").Replace("\r", "");
							//consoleBox.AppendText("Attempting download from 0xb00a8...");
							
							if(cleansedResponse.Equals("http/200")){
								consoleBox.AppendText("Connected to BPS downstreaming service \n");
								consoleBox.AppendText("add:0x000b00a8 mk:0x0004ff57 - STABLE -\n");
								statusLED.Text = "STREAMING";
								statusLED.ForeColor = Color.Orange;
								responseBL = false;
								downloadButton.Enabled = false;
								DownstreamFiles(port);
								break;
							}
						}
					}
					
				}
				
			}
			
		}
		
		public void DownstreamFiles(SerialPort port){
			string outputPath = filePathBrowser.Text;
			if(Directory.Exists(outputPath)){
				txLED.ForeColor = Color.Red;
				port.WriteLine("0x0a4fb77c");
				txLED.ForeColor = Color.Black;
				
				string outputPathFull = String.Format("{0}/BPS_STREAM_{1}{2}{3}{4}{5}{6}.csv",outputPath, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
			
				using (StreamWriter stream = File.CreateText(outputPathFull))
	            {
					while(true){
						rxLED.ForeColor = Color.Red;
						string streamInput = port.ReadLine();
						rxLED.ForeColor = Color.Black;
						string cleanInput = streamInput.Replace("\n", "").Replace("\r", "");
						
						if(cleanInput.Equals("0xb00a8:EOF")){
							consoleBox.AppendText("0x000b00a8 FINISHED STREAMING\n");
							devicePaired = false;
							statusLED.Text = "FINISH";
							statusLED.ForeColor = Color.Lime;
							consoleBox.AppendText("\n");
							consoleBox.AppendText("___________________________________________\n");
							consoleBox.AppendText("0x000b00a8 RESETING...\n");
							consoleBox.AppendText("0x000b00a8 >> 0x06fa3e22\n");
							consoleBox.AppendText("FILE IS READY IN YOUR DIRECTORY\n");
							consoleBox.AppendText("thanks for using BPSerial Downstreaming Tool\n");
							consoleBox.AppendText("____________by Levente Vendéghegyi__________\n");
							break;
						}else{
							int receivedBytes = cleanInput.Length;
							consoleBox.AppendText(String.Format("< {0} > bytes received from 0x000b00a8 \n", receivedBytes));
							stream.WriteLine(cleanInput);
						}
					}
						
	            }
			
				
			}else{
				consoleBox.AppendText("[ WARNING ] output path not exists");
			}
		}
		
		void Label5Click(object sender, EventArgs e)
		{
	
		}
		void browseFile(object sender, EventArgs e)
		{
			DialogResult folder = saveFileDialog.ShowDialog();
			 if(folder == DialogResult.OK){  
		        filePathBrowser.Text = saveFileDialog.SelectedPath;  
		        Environment.SpecialFolder root = saveFileDialog.RootFolder;  
		    }
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;




namespace ReadEnvSample
{	
    class Program
    {
        static void Main(string[] args)
        {
			
            var processes = Process.GetProcessesByName("Open Server x64");			
			
            if (processes.Length == 0){
                Console.WriteLine("Process with a given name not found. Please modify the code and specify the existing process name."); 
				
				processes = Process.GetProcessesByName("Open Server");	
				if (processes.Length == 0){
					MessageBox.Show("Start Open Server and try again!", "Process not found");
					System.Environment.Exit(0);
				}
				
				
			}
            
            
			
			Console.WriteLine();
			Console.WriteLine("Process with ID {0} has a PATH environment variable:", processes[0].Id);

			var env = processes[0].ReadEnvironmentVariables();

			string path = Environment.GetEnvironmentVariable("PATH");
			
			path += env["PATH"];
			
			Console.WriteLine(path);
				
				

				


            
			
			var startInfo = new ProcessStartInfo();
			// Sets RAYPATH variable to "test"
			// The new process will have RAYPATH variable created with "test" value
			// All environment variables of the created process are inherited from the
			// current process
			startInfo.EnvironmentVariables["PATH"] = path;

			// Required for EnvironmentVariables to be set
			startInfo.UseShellExecute = false;

			// Sets some executable name
			// The executable will be search in directories that are specified
			// in the PATH variable of the current process
			if(args.Length > 0){
				startInfo.FileName = args[0];
				Console.WriteLine(args[0]);
				// Starts process
				Process.Start(startInfo);
			}
			
        }
    }
}

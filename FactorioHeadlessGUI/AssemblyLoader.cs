using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace FactorioHeadlessGUI
{
    public static class AssemblyLoader
    {
        internal static Dictionary<string, Assembly> myDict;

        public static Assembly AssemblyResolve(object sender, ResolveEventArgs e)
        {
            if (myDict == null)
                myDict = new Dictionary<string, Assembly>(StringComparer.OrdinalIgnoreCase);
            string RealName = e.Name.Split(',')[0].Trim();
            if (myDict.ContainsKey(RealName))
                return myDict[RealName];
            else
            {
                byte[] bytes;
                string resourceName = "FactorioHeadlessGUI.Dlls." + RealName + ".dll";
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                using (Stream stream = currentAssembly.GetManifestResourceStream(resourceName))
                {
                    bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                }
                Assembly result = Assembly.Load(bytes);
                myDict.Add(RealName, result);
                bytes = null;
                return result;
            }
        }

        private static List<CLIlibrary> myCLIDict;

        public static void AddCLI(CLIlibrary _lib)
        {
            if (myCLIDict == null)
                myCLIDict = new List<CLIlibrary>();
            myCLIDict.Add(_lib);
            _lib.Extract();
        }

        public static void UnloadAllCLI()
        {
            if (myCLIDict != null && myCLIDict.Count > 0)
                foreach (CLIlibrary val in myCLIDict)
                    val.Delete();
        }//*/

        public class CLIlibrary
        {
            public string Filename { get; }
            public string FilenameInside86 { get; }
            public string FilenameInside64 { get; }

            public void Extract()
            {
                string resourceName = "FactorioHeadlessGUI.Dlls." + this.FilenameInside86;
                if (Environment.Is64BitProcess)
                    resourceName = "FactorioHeadlessGUI.Dlls." + this.FilenameInside64;
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                using (Stream stream = currentAssembly.GetManifestResourceStream(resourceName))
                using (FileStream fs = File.Create(Path.Combine(Leayal.AppInfo.AssemblyInfo.DirectoryPath, this.Filename)))
                {
                    stream.CopyTo(fs);
                    fs.Flush();
                }
            }

            public void Delete()
            {
                File.Delete(Path.Combine(Leayal.AppInfo.AssemblyInfo.DirectoryPath, this.Filename));
            }

            /*private IntPtr innerPointer;
            public IntPtr Pointer { get { return this.innerPointer; } }

            public IntPtr Load()
            {
                if (this.innerPointer != IntPtr.Zero)
                    return this.innerPointer;
                
                this.innerPath = Path.GetTempFileName();

                string resourceName = "PSO2ProxyLauncherNew.Dlls." + FilenameInside + ".dll";
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                using (Stream stream = currentAssembly.GetManifestResourceStream(resourceName))
                using (FileStream fs = File.Create(this.innerPath))
                {
                    stream.CopyTo(fs);
                    fs.Flush();
                }

                this.innerPointer = Classes.Infos.CommonMethods.LoadLib(this.innerPath);
                return this.innerPointer;
            }

            /*public IntPtr GetMethod()
            {
                IntPtr funcaddr = GetProcAddress(Handle, functionName);
                YourFunctionDelegate function = Marshal.GetDelegateForFunctionPointer(funcaddr, typeof(YourFunctionDelegate)) as YourFunctionDelegate;
                function.Invoke(pass here your parameters);
            }

            public bool Free()
            {
                if (this.innerPointer != IntPtr.Zero)
                {
                    bool result = Classes.Infos.CommonMethods.FreeLib(this.innerPointer);
                    File.Delete(this.innerPath);
                    this.innerPointer = IntPtr.Zero;
                    return result;
                }
                else
                    return false;
            }//*/

            public CLIlibrary(string _filename, string x86) : this(_filename, x86, string.Empty) { }

            public CLIlibrary(string _filename, string x86, string x64)
            {
                this.Filename = _filename;
                this.FilenameInside86 = x86;
                this.FilenameInside64 = x64;
            }
        }
    }
}

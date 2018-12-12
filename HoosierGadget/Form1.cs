using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Windows;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Xml;


namespace HoosierGadget
{
    //[DataContract]
    //[Serializable]
    //[KnownType]


    [KnownType(typeof(ButtonInfo))]
    public partial class Form1 : Form
    {
        public List<ButtonInfo> buttonInfo = null;
        MediaPlayer mediaPlayer = null;
        string strXmlPath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            label1.Text = label2.Text = label3.Text = label4.Text = label5.Text = label6.Text = label7.Text = label8.Text = label9.Text = label10.Text =
            label11.Text = label12.Text = label13.Text = label14.Text = label15.Text = label16.Text = label17.Text = label18.Text = label19.Text = label20.Text =
            label21.Text = label22.Text = label23.Text = label24.Text = label25.Text = label26.Text = label27.Text = label28.Text = label29.Text = label30.Text =
            label31.Text = label32.Text = label33.Text = label34.Text = label35.Text = label36.Text = label37.Text = label38.Text = label39.Text = label40.Text =
            label41.Text = label42.Text = label43.Text = label44.Text = label45.Text = label46.Text = label47.Text = label48.Text = label49.Text = label50.Text =
            label51.Text = label52.Text = label53.Text = label54.Text = label55.Text = label56.Text = label57.Text = label58.Text = label59.Text = label60.Text =
            label61.Text = label62.Text = label63.Text = label64.Text = label65.Text = label66.Text = label67.Text = label68.Text = label69.Text = label70.Text =
            label71.Text = label72.Text = label73.Text = label74.Text = label75.Text = label76.Text = label77.Text = label78.Text = label79.Text = label80.Text =
            label81.Text = label82.Text = label83.Text = label84.Text = label85.Text = label86.Text = label87.Text = label88.Text = label89.Text = label90.Text =
                String.Empty;

            this.Font = new Font(this.Font.FontFamily, (float)12, this.Font.Style);

            foreach (var button in Controls.OfType<Button>())
            {
                if (button.Text.Length == 1)
                {
                    button.Click -= button1_Click;
                    button.Click += button1_Click;
                }
            }

            buttonInfo = new List<ButtonInfo>();

            mediaPlayer = new MediaPlayer(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idxButton = -1;             // -1 means it's unassigned
            string strNewLabel = string.Empty;
            string strNewLabel_ShiftKey = string.Empty;
            Uri uriNewSoundFile = null;
            Uri uriNewSoundFile_ShiftKey = null;

            // find the index to button info based on caption
            if (buttonInfo.Count() > 0)
            {
                for (int i = 0; i < buttonInfo.Count(); i++)
                {
                    if (buttonInfo[i].strKey == (((Button)sender).Text))
                    {
                        idxButton = i;
                        break;
                    }
                }
            }
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MP3 Files|*.mp3";
            openFileDialog1.Title = "Select Non-Shift-Key Sound File for key [" + ((Button)sender).Text + "]";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                uriNewSoundFile = new System.Uri(openFileDialog1.FileName);
                strNewLabel = Microsoft.VisualBasic.Interaction.InputBox("Label for Non-Shift-Key Sound File?", "Enter Label Text for key [" + ((Button)sender).Text + "]", "");
                if (string.IsNullOrEmpty(strNewLabel))
                    return;
            }
            else return;


            openFileDialog1.Filter = "MP3 Files|*.mp3";
            openFileDialog1.Title = "Select Shift-Key Sound File for key [" + ((Button)sender).Text + "]";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                uriNewSoundFile_ShiftKey = new System.Uri(openFileDialog1.FileName);
                strNewLabel_ShiftKey = Microsoft.VisualBasic.Interaction.InputBox("Label for Shift-Key Sound File?", "Enter Label Text for key [" + ((Button)sender).Text + "]", "");
                if (string.IsNullOrEmpty(strNewLabel_ShiftKey))
                    return;
            }
            else return;

            if (idxButton == -1)            // unassigned key, need to add new entry to List
            {
                buttonInfo.Add(new ButtonInfo
                {
                    strKey = ((Button)sender).Text.ToLower(),
                    strLabel = strNewLabel,
                    strLabel_ShiftKey = strNewLabel_ShiftKey,
                    uriSoundFile = uriNewSoundFile,
                    uriSoundFile_ShiftKey = uriNewSoundFile_ShiftKey,
                });
            } else
            {
                buttonInfo[idxButton] = new ButtonInfo
                {
                    strKey = ((Button)sender).Text.ToLower(),
                    strLabel = strNewLabel,
                    strLabel_ShiftKey = strNewLabel_ShiftKey,
                    uriSoundFile = uriNewSoundFile,
                    uriSoundFile_ShiftKey = uriNewSoundFile_ShiftKey,
                };
            }

            ShowLabels(((Button)sender).Text.ToLower(), strNewLabel, strNewLabel_ShiftKey);

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if (keyData == (Keys.Shift | Keys.ShiftKey))
                return true;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                //bool bShiftKey = (keyData.HasFlag(Keys.Shift));
                //Keys keyDataLower = keyData;
                //keyData.GetHashCode();
                //keyDataLower.GetTypeCode

                switch (keyData)
                {
                    case Keys.A: PlaySound('a'); break;
                    case Keys.B: PlaySound('b'); break;
                    case Keys.C: PlaySound('c'); break;
                    case Keys.D: PlaySound('d'); break;
                    case Keys.E: PlaySound('e'); break;
                    case Keys.F: PlaySound('f'); break;
                    case Keys.G: PlaySound('g'); break;
                    case Keys.H: PlaySound('h'); break;
                    case Keys.I: PlaySound('i'); break;
                    case Keys.J: PlaySound('j'); break;
                    case Keys.K: PlaySound('k'); break;
                    case Keys.L: PlaySound('l'); break;
                    case Keys.M: PlaySound('m'); break;
                    case Keys.N: PlaySound('n'); break;
                    case Keys.O: PlaySound('o'); break;
                    case Keys.P: PlaySound('p'); break;
                    case Keys.Q: PlaySound('q'); break;
                    case Keys.R: PlaySound('r'); break;
                    case Keys.S: PlaySound('s'); break;
                    case Keys.T: PlaySound('t'); break;
                    case Keys.U: PlaySound('u'); break;
                    case Keys.V: PlaySound('v'); break;
                    case Keys.W: PlaySound('w'); break;
                    case Keys.X: PlaySound('x'); break;
                    case Keys.Y: PlaySound('y'); break;
                    case Keys.Z: PlaySound('z'); break;
                    case Keys.Shift | Keys.A: PlaySound('A'); break;
                    case Keys.Shift | Keys.B: PlaySound('B'); break;
                    case Keys.Shift | Keys.C: PlaySound('C'); break;
                    case Keys.Shift | Keys.D: PlaySound('D'); break;
                    case Keys.Shift | Keys.E: PlaySound('E'); break;
                    case Keys.Shift | Keys.F: PlaySound('F'); break;
                    case Keys.Shift | Keys.G: PlaySound('G'); break;
                    case Keys.Shift | Keys.H: PlaySound('H'); break;
                    case Keys.Shift | Keys.I: PlaySound('I'); break;
                    case Keys.Shift | Keys.J: PlaySound('J'); break;
                    case Keys.Shift | Keys.K: PlaySound('K'); break;
                    case Keys.Shift | Keys.L: PlaySound('L'); break;
                    case Keys.Shift | Keys.M: PlaySound('M'); break;
                    case Keys.Shift | Keys.N: PlaySound('N'); break;
                    case Keys.Shift | Keys.O: PlaySound('O'); break;
                    case Keys.Shift | Keys.P: PlaySound('P'); break;
                    case Keys.Shift | Keys.Q: PlaySound('Q'); break;
                    case Keys.Shift | Keys.R: PlaySound('R'); break;
                    case Keys.Shift | Keys.S: PlaySound('S'); break;
                    case Keys.Shift | Keys.T: PlaySound('T'); break;
                    case Keys.Shift | Keys.U: PlaySound('U'); break;
                    case Keys.Shift | Keys.V: PlaySound('V'); break;
                    case Keys.Shift | Keys.W: PlaySound('W'); break;
                    case Keys.Shift | Keys.X: PlaySound('X'); break;
                    case Keys.Shift | Keys.Y: PlaySound('Y'); break;
                    case Keys.Shift | Keys.Z: PlaySound('Z'); break;
                    case Keys.D1: PlaySound('1'); break;
                    case Keys.D2: PlaySound('2'); break;
                    case Keys.D3: PlaySound('3'); break;
                    case Keys.D4: PlaySound('4'); break;
                    case Keys.D5: PlaySound('5'); break;
                    case Keys.D6: PlaySound('6'); break;
                    case Keys.D7: PlaySound('7'); break;
                    case Keys.D8: PlaySound('8'); break;
                    case Keys.D9: PlaySound('9'); break;
                    case Keys.D0: PlaySound('0'); break;
                    case Keys.Shift | Keys.D1: PlaySound('!'); break;
                    case Keys.Shift | Keys.D2: PlaySound('@'); break;
                    case Keys.Shift | Keys.D3: PlaySound('#'); break;
                    case Keys.Shift | Keys.D4: PlaySound('$'); break;
                    case Keys.Shift | Keys.D5: PlaySound('%'); break;
                    case Keys.Shift | Keys.D6: PlaySound('^'); break;
                    case Keys.Shift | Keys.D7: PlaySound('&'); break;
                    case Keys.Shift | Keys.D8: PlaySound('*'); break;
                    case Keys.Shift | Keys.D9: PlaySound('('); break;
                    case Keys.Shift | Keys.D0: PlaySound(')'); break;
                    case Keys.OemCloseBrackets: PlaySound(']'); break;
                    case Keys.Shift | Keys.OemCloseBrackets: PlaySound('}'); break;
                    case Keys.Oemcomma: PlaySound(','); break;
                    case Keys.Shift | Keys.Oemcomma: PlaySound('<'); break;
                    case Keys.OemMinus: PlaySound('-'); break;
                    case Keys.Shift | Keys.OemMinus: PlaySound('_'); break;
                    case Keys.OemOpenBrackets: PlaySound('['); break;
                    case Keys.Shift | Keys.OemOpenBrackets: PlaySound('{'); break;
                    case Keys.OemPeriod: PlaySound('.'); break;
                    case Keys.Shift | Keys.OemPeriod: PlaySound('>'); break;
                    case Keys.Oemplus: PlaySound('='); break;
                    case Keys.Shift | Keys.Oemplus: PlaySound('+'); break;
                    case Keys.OemQuestion: PlaySound('/'); break;
                    case Keys.Shift | Keys.OemQuestion: PlaySound('?'); break;
                    case Keys.OemQuotes: PlaySound('\''); break;
                    case Keys.Shift | Keys.OemQuotes: PlaySound('"'); break;
                    case Keys.OemSemicolon: PlaySound(';'); break;
                    case Keys.Shift | Keys.OemSemicolon: PlaySound(':'); break;
                    case Keys.Space: StopSound(); break;
                    case Keys.Shift | Keys.Space: StopSound(); break;
                }


            }

            return true;
        }
        
        //void Form1_KeyDown(object sender, KeyPressEventArgs e)
        //{
        //}

        private void StopSound()
        {
            mediaPlayer.Stop();
        }

        private void ShowLabels(string strButtonText, string strNewLabel, string strNewLabel_ShiftKey)
        {
            int idxButton = -1;             // -1 means it's unassigned

            // find the index to button info based on caption
            if (buttonInfo.Count() > 0)
            {
                for (int i = 0; i < buttonInfo.Count(); i++)
                {
                    if (buttonInfo[i].strKey == strButtonText)
                    {
                        idxButton = i;
                        break;
                    }
                }
            }

            if (idxButton > -1)
            {
                switch (buttonInfo[idxButton].strKey[0])
                {
                    case '1': label1.Text = strNewLabel_ShiftKey; label2.Text = strNewLabel; break;
                    case '2': label4.Text = strNewLabel_ShiftKey; label3.Text = strNewLabel; break;
                    case '3': label6.Text = strNewLabel_ShiftKey; label5.Text = strNewLabel; break;
                    case '4': label12.Text = strNewLabel_ShiftKey; label11.Text = strNewLabel; break;
                    case '5': label10.Text = strNewLabel_ShiftKey; label9.Text = strNewLabel; break;
                    case '6': label8.Text = strNewLabel_ShiftKey; label7.Text = strNewLabel; break;
                    case '7': label18.Text = strNewLabel_ShiftKey; label17.Text = strNewLabel; break;
                    case '8': label16.Text = strNewLabel_ShiftKey; label15.Text = strNewLabel; break;
                    case '9': label14.Text = strNewLabel_ShiftKey; label13.Text = strNewLabel; break;
                    case '0': label24.Text = strNewLabel_ShiftKey; label23.Text = strNewLabel; break;
                    case '-': label22.Text = strNewLabel_ShiftKey; label21.Text = strNewLabel; break;
                    case '=': label20.Text = strNewLabel_ShiftKey; label19.Text = strNewLabel; break;
                    case 'q': label30.Text = strNewLabel_ShiftKey; label29.Text = strNewLabel; break;
                    case 'w': label28.Text = strNewLabel_ShiftKey; label27.Text = strNewLabel; break;
                    case 'e': label26.Text = strNewLabel_ShiftKey; label25.Text = strNewLabel; break;
                    case 'r': label36.Text = strNewLabel_ShiftKey; label35.Text = strNewLabel; break;
                    case 't': label34.Text = strNewLabel_ShiftKey; label33.Text = strNewLabel; break;
                    case 'y': label32.Text = strNewLabel_ShiftKey; label31.Text = strNewLabel; break;
                    case 'u': label42.Text = strNewLabel_ShiftKey; label41.Text = strNewLabel; break;
                    case 'i': label40.Text = strNewLabel_ShiftKey; label39.Text = strNewLabel; break;
                    case 'o': label38.Text = strNewLabel_ShiftKey; label37.Text = strNewLabel; break;
                    case 'p': label48.Text = strNewLabel_ShiftKey; label47.Text = strNewLabel; break;
                    case '[': label46.Text = strNewLabel_ShiftKey; label45.Text = strNewLabel; break;
                    case ']': label44.Text = strNewLabel_ShiftKey; label43.Text = strNewLabel; break;
                    case 'a': label54.Text = strNewLabel_ShiftKey; label53.Text = strNewLabel; break;
                    case 's': label52.Text = strNewLabel_ShiftKey; label51.Text = strNewLabel; break;
                    case 'd': label50.Text = strNewLabel_ShiftKey; label49.Text = strNewLabel; break;
                    case 'f': label60.Text = strNewLabel_ShiftKey; label59.Text = strNewLabel; break;
                    case 'g': label58.Text = strNewLabel_ShiftKey; label57.Text = strNewLabel; break;
                    case 'h': label56.Text = strNewLabel_ShiftKey; label55.Text = strNewLabel; break;
                    case 'j': label66.Text = strNewLabel_ShiftKey; label65.Text = strNewLabel; break;
                    case 'k': label64.Text = strNewLabel_ShiftKey; label63.Text = strNewLabel; break;
                    case 'l': label62.Text = strNewLabel_ShiftKey; label61.Text = strNewLabel; break;
                    case ';': label88.Text = strNewLabel_ShiftKey; label87.Text = strNewLabel; break;
                    case '\'' : label90.Text = strNewLabel_ShiftKey; label89.Text = strNewLabel; break;
                    case 'z': label72.Text = strNewLabel_ShiftKey; label71.Text = strNewLabel; break;
                    case 'x': label70.Text = strNewLabel_ShiftKey; label69.Text = strNewLabel; break;
                    case 'c': label68.Text = strNewLabel_ShiftKey; label67.Text = strNewLabel; break;
                    case 'v': label78.Text = strNewLabel_ShiftKey; label77.Text = strNewLabel; break;
                    case 'b': label76.Text = strNewLabel_ShiftKey; label75.Text = strNewLabel; break;
                    case 'n': label74.Text = strNewLabel_ShiftKey; label73.Text = strNewLabel; break;
                    case 'm': label84.Text = strNewLabel_ShiftKey; label83.Text = strNewLabel; break;
                    case ',': label82.Text = strNewLabel_ShiftKey; label81.Text = strNewLabel; break;
                    case '.': label80.Text = strNewLabel_ShiftKey; label79.Text = strNewLabel; break;
                    case '/': label86.Text = strNewLabel_ShiftKey; label85.Text = strNewLabel; break;
                }
            }
        }

        private void PlaySound(char keyPressed)
        {
            bool bShiftKey = false;
            byte bKeyPressed = (byte)keyPressed;

            if ((bKeyPressed >= 33 && bKeyPressed <= 38) ||
                (bKeyPressed >= 40 && bKeyPressed <= 43) ||
                bKeyPressed == 58 ||
                bKeyPressed == 60 ||
                bKeyPressed == 62 ||
                (bKeyPressed >= 63 && bKeyPressed <= 90) ||
                bKeyPressed == 94 ||
                bKeyPressed == 95 ||
                bKeyPressed == 123 ||
                bKeyPressed == 125
                    )
                bShiftKey = true;

            if (bShiftKey)
            {
                switch (bKeyPressed)
                {
                    case 33: keyPressed = '1'; break;
                    case 34: keyPressed = '\''; break;
                    case 35: keyPressed = '3'; break;
                    case 36: keyPressed = '4'; break;
                    case 37: keyPressed = '5'; break;
                    case 38: keyPressed = '7'; break;
                    case 40: keyPressed = '9'; break;
                    case 41: keyPressed = '0'; break;
                    case 42: keyPressed = '8'; break;
                    case 43: keyPressed = '='; break;
                    case 58: keyPressed = ';'; break;
                    case 60: keyPressed = ','; break;
                    case 62: keyPressed = '.'; break;
                    case 63: keyPressed = '/'; break;
                    case 64: keyPressed = '2'; break;
                    case 94: keyPressed = '6'; break;
                    case 95: keyPressed = '-'; break;
                    case 123: keyPressed = '['; break;
                    case 125: keyPressed = ']'; break;
                    default: if (bKeyPressed >= 63 && bKeyPressed <= 90)
                                    keyPressed = (char)(bKeyPressed + 32);
                                break;
                }
            }

            bKeyPressed = (byte)keyPressed;             // refresh in case value changed

            int idxButton = -1;

            // find the index to button info based on key pressed
            if (buttonInfo.Count() > 0)
            {
                for (int i = 0; i < buttonInfo.Count(); i++)
                {
                    if (buttonInfo[i].strKey == keyPressed.ToString())
                    {
                        idxButton = i;
                        break;
                    }
                }
            }

            if (idxButton > -1)
            {

                if (!bShiftKey)
                    mediaPlayer.Open(buttonInfo[idxButton].uriSoundFile);
                else
                    mediaPlayer.Open(buttonInfo[idxButton].uriSoundFile_ShiftKey);

                mediaPlayer.Play();
            }
        }

        private void button25_Click(object sender, EventArgs e)             // save settings
        {
            DoSerialize();


        }

        private void button37_Click(object sender, EventArgs e)             // load settings
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML Files|*.xml";
            openFileDialog1.Title = "Select Settings File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strXmlPath = openFileDialog1.FileName;          // needed for deserialization to generate absolute paths

                using (FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    int size = (int)stream.Length; // Returns the length of the file
                    byte[] data = new byte[size]; // Initializes and array in which to store the file
                    stream.Read(data, 0, size); // Begins to read from the constructed stream

                    AllButtonInfo allInfo = new AllButtonInfo();
                    allInfo = AllButtonInfo.Deserialize(System.Text.Encoding.Default.GetString(data), strXmlPath);

                    buttonInfo.Clear();
                    buttonInfo = allInfo.buttonInfo;

                    // update the labels
                    for (int i = 0; i < buttonInfo.Count(); i++)
                    {
                        ShowLabels(buttonInfo[i].strKey.ToLower(), buttonInfo[i].strLabel, buttonInfo[i].strLabel_ShiftKey);
                    }
                }
                //buttonInfo.Add(new ButtonInfo
                //{
                //    strKey = ((Button)sender).Text.ToLower(),
                //    strLabel = strNewLabel,
                //    strLabel_ShiftKey = strNewLabel_ShiftKey,
                //    uriSoundFile = uriNewSoundFile,
                //    uriSoundFile_ShiftKey = uriNewSoundFile_ShiftKey,
                //});
            }
        }

        public void DoSerialize()
        {

            //var result = new StringBuilder();
            ////Type typeObj = obj.GetType() as Type;

            //DataContractSerializer serializer = new DataContractSerializer(typeof(AllButtonInfo));

            //using (var stringWriter = new StringWriter(result))
            //using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
            //{
            //    serializer.WriteObject(xmlWriter, typeObj);
            //}

            AllButtonInfo allInfo = new AllButtonInfo();
            allInfo.buttonInfo = buttonInfo;

            string serialisedToString = allInfo.Serialize();


            //MessageBox.Show(serialisedToString);



            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML Files|*.xml";
            saveFileDialog1.Title = "Save Settings File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.  
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();

                byte[] xmlText = new UTF8Encoding(true).GetBytes(serialisedToString);

                fs.Write(xmlText, 0, xmlText.Length);

                //// writing data in bytes already
                //byte[] data = new byte[] { 0x0 };
                //fs.Write(data, 0, data.Length);

                fs.Close();
            }
        }
    }

    public class ButtonInfo : object
    {

        public string strKey { get; set; }                      // which keyboard key is assigned
        public string strLabel { get; set; }                   // label to display below key
        public string strLabel_ShiftKey { get; set; }
        public Uri uriSoundFile { get; set; }
        public Uri uriSoundFile_ShiftKey { get; set; }

    };

    [DataContract]
    public class AllButtonInfo : object
    {
        public AllButtonInfo() { }

        [DataMember]
        public List<ButtonInfo> buttonInfo { get; set; }

        public string Serialize()
        {
            StringBuilder xml = new StringBuilder();
            DataContractSerializer serializer = new DataContractSerializer(typeof(AllButtonInfo));

            AllButtonInfo objWithTransforms = this;

            for(int i=0; i < objWithTransforms.buttonInfo.Count(); i++)
            {
                ButtonInfo info = objWithTransforms.buttonInfo[i];

                info.uriSoundFile = new Uri(Path.GetFileName(info.uriSoundFile.LocalPath), UriKind.Relative);
                info.uriSoundFile_ShiftKey = new Uri(Path.GetFileName(info.uriSoundFile_ShiftKey.LocalPath), UriKind.Relative);

                objWithTransforms.buttonInfo[i] = info;
            }

            using (XmlWriter xw = XmlWriter.Create(xml))
            {
                serializer.WriteObject(xw, objWithTransforms);
                xw.Flush();
                return xml.ToString();
            }
        }

        public static AllButtonInfo Deserialize(string xml, string strXmlPath)
        {
            AllButtonInfo newItem;
            string strXmlPathOnly = Path.GetDirectoryName(strXmlPath) + "\\";
            DataContractSerializer serializer = new DataContractSerializer(typeof(AllButtonInfo));
            StringReader textReader = new StringReader(xml);
            
            using (XmlReader xr = XmlReader.Create(textReader))
            {
                newItem = (AllButtonInfo)serializer.ReadObject(xr);
            }

            for(int i=0; i < newItem.buttonInfo.Count(); i++)
            {
                ButtonInfo info = newItem.buttonInfo[i];

                info.uriSoundFile = new Uri(strXmlPathOnly + Path.GetFileName(info.uriSoundFile.ToString()), UriKind.Absolute);
                info.uriSoundFile_ShiftKey = new Uri(strXmlPathOnly + Path.GetFileName(info.uriSoundFile_ShiftKey.ToString()), UriKind.Absolute);

                newItem.buttonInfo[i] = info;
            }

            return newItem;
        }
    };

}

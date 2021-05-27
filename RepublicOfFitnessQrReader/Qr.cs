using System;
using System.IO;
using System.Linq;
using System.Text;
using WebCam_Capture;
using System.Collections.Generic;
using OnBarcode.Barcode.BarcodeScanner;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Sockets;


namespace RepublicOfFitnessQrReader
{
    class Qr
    {
        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ROFSystemConnection"].ToString();
        private WebCamCapture webcam;
        private System.Windows.Forms.PictureBox _FrameImage;
        private int FrameNumber = 30;

        public void InitializeWebCam(ref System.Windows.Forms.PictureBox ImageControl)
        {
            webcam = new WebCamCapture();
            webcam.FrameNumber = ((ulong)(0ul));
            webcam.TimeToCapture_milliseconds = FrameNumber;
            webcam.ImageCaptured += new WebCamCapture.WebCamEventHandler(webcam_ImageCaptured);
            _FrameImage = ImageControl;
        }

        void webcam_ImageCaptured(object source, WebcamEventArgs e)
        {
            _FrameImage.Image = e.WebCamImage;
        }

        public void Start()
        {
            webcam.TimeToCapture_milliseconds = FrameNumber;
            webcam.Start(0);
        }

        public void ResolutionSetting()
        {
            webcam.Config();
        }

        public void AdvanceSetting()
        {
            webcam.Config2();
        }

        internal string TimeInOrTimeOutMember(string MemberID)
        {
            MemberID = "ROF-" + MemberID.Remove(0, 4);

            if (CheckIfMemberIDExists(MemberID))
            {
                if (CheckIfTimedIn(MemberID, DateTime.Today.ToShortDateString()) == false)
                {
                    if (CheckLastTimeInOrOutIfMoreThan2Mins("TimeIn", MemberID))
                    {
                        InsertTimeInOrTimeOut("TimeIn", MemberID, DateTime.Now.ToString("HH:mm tt"));
                        return "Member with the ID " + MemberID + " has timed in at " + DateTime.Now.ToString("hh:mm tt") + ".";
                    }
                    else
                        return "";
                }

                else
                {
                    if (CheckLastTimeInOrOutIfMoreThan2Mins("TimeOut", MemberID))
                    {
                        InsertTimeInOrTimeOut("TimeOut", MemberID, DateTime.Now.ToString("HH:mm tt"));
                        return "Member with the ID " + MemberID + " has timed out at " + DateTime.Now.ToString("hh:mm tt") + ".";
                    }
                    else
                        return "";
                }
            }

            else
            {
                return "The Member ID does not exist.";
            }
        }

        private bool CheckLastTimeInOrOutIfMoreThan2Mins(string TimeInOrTimeOut, string MemberID)
        {
            string CheckLastTimeInOrOutIfMoreThan2MinsQuery = "";

            if (TimeInOrTimeOut == "TimeIn")
                CheckLastTimeInOrOutIfMoreThan2MinsQuery = "select top 1 MemberTimeKeeping_TimeOut from MemberTimeKeeping where MemberTimeKeeping_MemberID = '" + MemberID + "' ORDER BY   MemberTimeKeeping_date DESC, MemberTimeKeeping_TimeOut desc";
            else
                CheckLastTimeInOrOutIfMoreThan2MinsQuery = "select top 1 MemberTimeKeeping_Timein from MemberTimeKeeping where MemberTimeKeeping_MemberID = '" + MemberID + "' ORDER BY   MemberTimeKeeping_date DESC, MemberTimeKeeping_Timein desc";


            SqlConnection CheckLastTimeInOrOutIfMoreThan2MinsConnnection = new SqlConnection(ConnectionString);
            SqlCommand CheckLastTimeInOrOutIfMoreThan2MinsCommand = new SqlCommand(CheckLastTimeInOrOutIfMoreThan2MinsQuery, CheckLastTimeInOrOutIfMoreThan2MinsConnnection);

            try
            {
                CheckLastTimeInOrOutIfMoreThan2MinsConnnection.Open();
                DateTime TimeInOrOut = Convert.ToDateTime((CheckLastTimeInOrOutIfMoreThan2MinsCommand.ExecuteScalar()).ToString());

                if (TimeInOrOut.TimeOfDay < DateTime.Now.AddMinutes(-2.00).TimeOfDay)
                    return true;
                else
                    return false;
            }
            finally
            {
                CheckLastTimeInOrOutIfMoreThan2MinsConnnection.Close();
            }
        }

        private void InsertTimeInOrTimeOut(string TimeInOrTimeOut, string MemberID, string Time)
        {
            string InsertTimeInOrTimeOutQuery = "";
            string date = DateTime.Today.ToShortDateString();

            if (TimeInOrTimeOut == "TimeIn")
                InsertTimeInOrTimeOutQuery = "INSERT INTO MemberTimeKeeping (MemberTimeKeeping_MemberID, MemberTimeKeeping_Date, MemberTimeKeeping_TimeIn) VALUES('" + MemberID + "', '" + date + "', '" + Time + "')";
            else
                InsertTimeInOrTimeOutQuery = "update MemberTimeKeeping set MemberTimeKeeping_TimeOut = '" + Time + "' where MemberTimeKeeping_ID = '" + GetMemberTimeKeepingID(MemberID) + "'";

            SqlConnection InsertTimeInOrTimeOutConnnection = new SqlConnection(ConnectionString);
            SqlCommand InsertTimeInOrTimeOutCommand = new SqlCommand(InsertTimeInOrTimeOutQuery, InsertTimeInOrTimeOutConnnection);

            InsertTimeInOrTimeOutConnnection.Open();
            InsertTimeInOrTimeOutCommand.ExecuteNonQuery();
            InsertTimeInOrTimeOutConnnection.Close();
        }

        private int GetMemberTimeKeepingID(string MemberID)
        {
            SqlConnection InsertTimeInOrOutConnnection = new SqlConnection(ConnectionString);
            SqlCommand InsertTimeInOrOutCommand = new SqlCommand("SELECT TOP 1 MemberTimeKeeping_ID FROM MemberTimeKeeping WHERE (MemberTimeKeeping_MemberID = '" + MemberID + "') AND (MemberTimeKeeping_TimeOut IS NULL) ORDER BY   MemberTimeKeeping_date DESC, MemberTimeKeeping_TimeOut desc", InsertTimeInOrOutConnnection);

            try
            {
                InsertTimeInOrOutConnnection.Open();
                return Convert.ToInt32(InsertTimeInOrOutCommand.ExecuteScalar());
            }
            finally
            {
                InsertTimeInOrOutConnnection.Close();
            }
        }

        private bool CheckIfTimedIn(string MemberID, string date)
        {
            SqlConnection CheckIfTimedInConnnection = new SqlConnection(ConnectionString);
            SqlCommand CheckIfTimedInCommand = new SqlCommand("SELECT COUNT(MemberTimeKeeping_ID) AS IdCount FROM MemberTimeKeeping WHERE (MemberTimeKeeping_MemberID = '" + MemberID + "') AND (MemberTimeKeeping_date = '" + date + "') AND (MemberTimeKeeping_TimeOut IS NULL)", CheckIfTimedInConnnection);

            try
            {
                CheckIfTimedInConnnection.Open();
                if (Convert.ToInt32(CheckIfTimedInCommand.ExecuteScalar()) > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                CheckIfTimedInConnnection.Close();
            }
        }

        private bool CheckIfMemberIDExists(string RawMemberID)
        {
            if (RawMemberID.Length > 8)
                return false;

            else
            {
                SqlConnection CheckIfMemberIDExistsConnection = new SqlConnection(ConnectionString);
                SqlCommand CheckIfMemberIDExistsCommand = new SqlCommand("SELECT COUNT(MemberDetails_MemberID) AS MemberIDCount FROM MemberDetails WHERE MemberDetails_MemberID = '" + RawMemberID + "'", CheckIfMemberIDExistsConnection);

                try
                {
                    CheckIfMemberIDExistsConnection.Open();
                    if (Convert.ToInt32(CheckIfMemberIDExistsCommand.ExecuteScalar().ToString()) > 0)
                        return true;
                    else
                        return false;
                }

                finally
                {
                    CheckIfMemberIDExistsConnection.Close();
                }
            }
        }

//        public  DateTime GetFastestNISTDate()
//        {
//            var result = DateTime.MinValue;
//            // Initialize the list of NIST time servers
//            // http://tf.nist.gov/tf-cgi/servers.cgi
//            string[] servers = new string[] {
//"nist1-ny.ustiming.org",
//"nist1-nj.ustiming.org",
//"nist1-pa.ustiming.org",
//"time-a.nist.gov",
//"time-b.nist.gov",
//"nist1.aol-va.symmetricom.com",
//"nist1.columbiacountyga.gov",
//"nist1-chi.ustiming.org",
//"nist.expertsmi.com",
//"nist.netservicesgroup.com"
//            };

//            // Try 5 servers in random order to spread the load
//            Random rnd = new Random();
//            foreach (string server in servers.OrderBy(s => rnd.NextDouble()).Take(5))
//            {
//                try
//                {
//                    // Connect to the server (at port 13) and get the response
//                    string serverResponse = string.Empty;
//                    using (var reader = new StreamReader(new System.Net.Sockets.TcpClient(server, 13).GetStream()))
//                    {
//                        serverResponse = reader.ReadToEnd();
//                    }

//                    // If a response was received
//                    if (!string.IsNullOrEmpty(serverResponse))
//                    {
//                        // Split the response string ("55596 11-02-14 13:54:11 00 0 0 478.1 UTC(NIST) *")
//                        string[] tokens = serverResponse.Split(' ');

//                        // Check the number of tokens
//                        if (tokens.Length >= 6)
//                        {
//                            // Check the health status
//                            string health = tokens[5];
//                            if (health == "0")
//                            {
//                                // Get date and time parts from the server response
//                                string[] dateParts = tokens[1].Split('-');
//                                string[] timeParts = tokens[2].Split(':');

//                                // Create a DateTime instance
//                                DateTime utcDateTime = new DateTime(
//                                    Convert.ToInt32(dateParts[0]) + 2000,
//                                    Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]),
//                                    Convert.ToInt32(timeParts[0]), Convert.ToInt32(timeParts[1]),
//                                    Convert.ToInt32(timeParts[2]));

//                                // Convert received (UTC) DateTime value to the local timezone
//                                result = utcDateTime.ToLocalTime();

//                                return result;
//                                // Response successfully received; exit the loop

//                            }
//                        }
//                    }
//                }
//                catch
//                {
//                    // Ignore exception and try the next server
//                }
//            }
//            return result;
//        }
    }
}
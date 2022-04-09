using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace First_Try.Controllers

{
   
    

public class Jira
    {
        private String loginResponse;
        private String jSessionId;
        private String jsonData;
        private String csvData;
        private String writeToFileOutput;
        private String baseURL;
        private String loginAPI;
        private String biExportAPI;
        private String analysisStartDate;
        private String analysisEndDate;
        private String loginUserName;
        private String loginPassWord;
        private bool errorsOccurred;
        private String exportDir;

        public Jira()
        {
            this.baseURL = "https://end-of-study.atlassian.net/rest/";
           // this.loginAPI = newLoginAPI;
            this.biExportAPI = "getbusinessintelligenceexport/1.0/message";
            this.analysisStartDate = "01-DEC-18";
            this.analysisEndDate = "31-DEC-18";
            this.loginUserName = "AMALMAALAOUI6";
            this.loginPassWord = "capgemini_123";
            this.loginResponse = "";
            this.jSessionId = "";
            this.jsonData = "";
            this.csvData = "";
            this.writeToFileOutput = "";
            this.errorsOccurred = false;
            this.exportDir = "./First_Try/";

        }
    

    public string getBacklog()
    {
        try
        {


                string rt;
                WebRequest request = WebRequest.Create("https://end-of-study.atlassian.net/rest/agile/1.0/board");
                request.Headers.Add("Authorization", "Basic YW1hbG1hYWxhb3VpNkBnbWFpbC5jb206bnF2aWxtQzNzeG9Ia3c1NWJmcjk0QThB");


                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

               // Console.WriteLine(rt);

                return rt;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in loginToJira: " + ex);
            this.errorsOccurred = true;
                return "error";
        }
    }

        public string getSprints(int boardId)
        {
            try
            {


                string rt;
                WebRequest request = WebRequest.Create("https://end-of-study.atlassian.net/rest/agile/1.0/board/"+boardId+"/sprint");
                request.Headers.Add("Authorization", "Basic YW1hbG1hYWxhb3VpNkBnbWFpbC5jb206bnF2aWxtQzNzeG9Ia3c1NWJmcjk0QThB");


                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                // Console.WriteLine(rt);

                return rt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in loginToJira: " + ex);
                this.errorsOccurred = true;
                return "error";
            }
        }

       

        public string getVersionReleases(int boardId)
        {
            try
            {


                string rt;
                WebRequest request = WebRequest.Create("https://end-of-study.atlassian.net/rest/agile/1.0/board/" + boardId + "/version");
                request.Headers.Add("Authorization", "Basic YW1hbG1hYWxhb3VpNkBnbWFpbC5jb206bnF2aWxtQzNzeG9Ia3c1NWJmcjk0QThB");


                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                

                return rt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in loginToJira: " + ex);
                this.errorsOccurred = true;
                return "error";
            }
        }


        public string getIssue(int boardId, int sprintId)
        {
           
            try
            {


                string rt;
                WebRequest request = WebRequest.Create("https://end-of-study.atlassian.net/rest/agile/1.0/board/" + boardId + "/sprint/" + sprintId + "/issue");
                request.Headers.Add("Authorization", "Basic YW1hbG1hYWxhb3VpNkBnbWFpbC5jb206bnF2aWxtQzNzeG9Ia3c1NWJmcjk0QThB");


                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                // Console.WriteLine(rt);

                return rt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in loginToJira: " + ex);
                this.errorsOccurred = true;
                return "error";
            }
        }


        public void ParseJSessionID()
    {
        try
        {
            var dynObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(this.loginResponse);
            this.jSessionId = dynObj["session"]["value"].Value;
            Console.WriteLine("\njSessionId:");
            Console.WriteLine(this.jSessionId);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in parseJSessionID: " + ex);
            this.errorsOccurred = true;
        }
    }

    public void parseJSessionID()
    {
        try
        {
            var dynObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(this.loginResponse);
            this.jSessionId = dynObj["session"]["value"].Value;
            Console.WriteLine("\njSessionId:");
            Console.WriteLine(this.jSessionId);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in parseJSessionID: " + ex);
            this.errorsOccurred = true;
        }
    }


    /// <summary>
    ///     This method calls a given Jira API (using a the JSESSIONID 
    ///     property set by the call to the parseJSessionID method)
    ///     to authenticate the request), then writes the resulting 
    ///     response into the jsonData property.
    /// </summary>
    public void getJsonData()
    {
        try
        {
            String url = this.baseURL + this.biExportAPI + "?startDate=" + this.analysisStartDate + "&endDate=" + this.analysisEndDate;
            //String url = this.baseURL + "api/2/user?username=alexA";
            //String url = this.baseURL + "api/2/issue/picker" + "?currentJQL=assignee%3Dadmin";

            WebRequest request = WebRequest.Create(url);
            request.Headers["Cookie"] = "JSESSIONID=" + this.jSessionId;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            this.jsonData = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            Console.WriteLine("\njsonData:");
            Console.WriteLine(this.jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in getJsonData: " + ex);
            this.errorsOccurred = true;
        }
    }

    public void formatAsCSV()
    {
        try
        {
            var dynObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(this.jsonData);
            String records = dynObj["records"].ToString();
            JArray a = JArray.Parse(records);
            List<String> colNames = new List<String>() { "recordType", "project", "projectId", "projectName", "projectLeadUser", "issueKey", "issueId", "issueCreated", "issueUpdated", "issueCreatorUserName", "issueDueDate", "issueRemainingEstimate", "issueOriginalEstimate", "issuePriority", "issueReporter", "issueStatus", "issueTotalTimeSpent", "issueVotes", "issueWatches", "issueResolution", "issueResolutionDate", "commentId", "commentAuthor", "commentAuthorKey", "commentCreated", "commentUpdated", "commentUpdateAuthor", "worklogId", "worklogAuthor", "worklogAuthorKey", "worklogCreated", "worklogStarted", "worklogUpdated", "worklogTimeSpent", "commentText", "worklogText" };

            String headerRow = "";
            foreach (String colName in colNames)
            {
                headerRow += "\"" + colName + "\",";
            }
            headerRow = headerRow.TrimEnd(',');
            headerRow += "\n";

            String dataRows = "";
            foreach (var record in a)
            {
                String thisRecord = "";
                foreach (String colName in colNames)
                {
                    thisRecord += "\"" + record[colName] + "\",";
                }
                thisRecord = thisRecord.TrimEnd(',');
                thisRecord += "\n";
                dataRows += thisRecord;
            }

            this.csvData = headerRow + dataRows;

            Console.WriteLine("\ncsvData:");
            Console.WriteLine(this.csvData);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in formatAsCSV: " + ex);
            this.errorsOccurred = true;
        }
    }


    /// <summary>
    ///     This method builds a timestamp for the uses it to create
    ///     a filename for the CSV data generated by the previous 
    ///     methods.  Then, it writes that CSV data into a CSV file 
    ///     in a directory specified by the exportDirectory
    ///     property.
    /// </summary>
    public void writeToFile()
    {
        try
        {
            String timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            String fileName = this.exportDir + "records_" + timeStamp + ".csv";
            File.WriteAllText(fileName, this.csvData);
            String fullPath = Path.GetFullPath(fileName);
            FileInfo f = new FileInfo(fileName);
            long bytesWritten = f.Length;
            this.writeToFileOutput = "SUCCESS: " + bytesWritten + " bytes written to " + fullPath;
            Console.WriteLine("\nwriteToFileOutput:");
            Console.WriteLine(this.writeToFileOutput);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in writeToFile: " + ex);
            this.errorsOccurred = true;
        }
    }
}

}
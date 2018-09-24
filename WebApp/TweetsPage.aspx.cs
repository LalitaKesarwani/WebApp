using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Model;

namespace WebApp
{
    public partial class TweetsPage : System.Web.UI.Page
    {
        static Dictionary<string, TweetModel> dict;
        int val = 1;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string val1 = Request["startdate"];

                string val2 = Request["enddate"];


                dt.Columns.Add("Tweeted Text");
                dt.Columns.Add("Tweeted Around");

                Button2.Visible = false;


                GetTweets(val1, val2);


                if (Cache["Table_Values"] == null)
                    GridView1.DataSource = ViewState["Table"];

                else
                    GridView1.DataSource = Cache["Table_Values"];

                GridView1.DataBind();


            }
        }
            private void GetTweets(string startdate, string enddate)
            {

                DateTime date1 = Convert.ToDateTime(startdate);
                int day1 = date1.Day;
                int month1 = date1.Month;
                int year1 = date1.Year;


                DateTime date2 = Convert.ToDateTime(enddate);
                int day2 = date2.Day;
                int month2 = date2.Month;
                int year2 = date2.Year;

                DateTime startDate = new DateTime(year1, month1, day1, 00, 00, 00,
                                    DateTimeKind.Utc);

                DateTime endDate = new DateTime(year2, month2, day2, 23, 59, 59,
                                        DateTimeKind.Utc);

                // ------------------------------------------------Consuming the  Rest API----------------------------------------------------------------------------------------
                WebClient client = new WebClient();
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                client.QueryString.Add("startDate", startDate
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                client.QueryString.Add("endDate", endDate
                    .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                string result = client.DownloadString("https://badapi.iqvia.io/api/v1/Tweets");
                List<TweetModel> md = JsonConvert.DeserializeObject<List<TweetModel>>(result);
                int count = md.Count();

                //-----------Since the API will give 100 values in a single response we can take the last date in the values received so that for the next call the start date will the last date in the API response and last date will be same ---------------------------
                DateTime date = Convert.ToDateTime(md[count - 1].Stamp);
                int day = date.Day;
                int month = date.Month;
                int year = date.Year;


                // ------------------- Adding to dictionary coz dictionary will not store duplicate tweets and they are being filtered using Tweet ID--------------------------------------------------------------------------------
                AddToDictionary(md);

                //Console.WriteLine("Another Set starts");
                //string date1 = (Convert.ToDateTime(md[99].stamp)).ToShortDateString();

                //------------------- ViewState coz each post back will loose the state. With the help of ViewState we can maintain the state --------------------------------------------------
                ViewState["startdate"] = md[count - 1].Stamp;

            }


            private void AddToDictionary(List<TweetModel> md)
            {
                // ----------- This method will save the most initial values obtained from the API Response.------------------------------------------------
                dict = new Dictionary<string, TweetModel>();

                foreach (TweetModel tweet in md)
                {
                    dict.Add(tweet.Id, tweet);
                    DataRow row = dt.NewRow();

                    //row["Tweet Id"] = tweet.Id;
                    row["Tweeted Text"] = tweet.Text;
                    row["Tweeted Around"] = Convert.ToDateTime(tweet.Stamp);
                    dt.Rows.Add(row);
                    val++;

                }
                ViewState["count"] = val;

                ViewState["Table"] = dt;

                Cache["Table_Values"] = ViewState["Table"];
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // ------------ Load More Funcionality will load and append another set of tweets into the GridView--------------------------------
            string newdate = (ViewState["startdate"]).ToString();
            DateTime date1 = Convert.ToDateTime(newdate);
            int day = date1.Day;
            int month = date1.Month;
            int year = date1.Year;

            DateTime startDate = new DateTime(year, month, day, 00, 00, 00,
                                        DateTimeKind.Utc);
            DateTime endDate = new DateTime(2017, 12, 31, 23, 59, 59,
                                DateTimeKind.Utc);

            if (startDate <= endDate)
            {

                // -------------Consuming The Client Rest API.-------------------------------------------------------
                WebClient client = new WebClient();
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                client.QueryString.Add("startDate", startDate
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                client.QueryString.Add("endDate", endDate
                    .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                string result = client.DownloadString("https://badapi.iqvia.io/api/v1/Tweets");
                List<TweetModel> md = JsonConvert.DeserializeObject<List<TweetModel>>(result);
                int count = md.Count();
                AddnewtoDictionary(md);

                ViewState["startdate"] = md[count - 1].Stamp;
                if (Cache["Table_Values"] == null)
                    GridView1.DataSource = ViewState["Table"];

                else
                    GridView1.DataSource = Cache["Table_Values"];

                GridView1.DataBind();
            }

            else
            {
                Response.Write("<script>alert('No more data to be displayed')</script>");
                Button1.Visible = false;
                Button2.Visible = true;
            }

        }

        private void AddnewtoDictionary(List<TweetModel> md)
        {

            //----------------This is the method used to store the values into the dictionary post post back------------------------------------

            dt1.Columns.Add("Tweeted Text");
            dt1.Columns.Add("Tweeted Around");



            List<string> keys = new List<string>();
            keys = dict.Keys.ToList();
            int val = (int)ViewState["count"];
            foreach (TweetModel tweet in md)
            {
                if (keys.Contains(tweet.Id))
                {
                    //------------------------------------------ Since here we will get duplicates so not storing the tweet into dictionary.---------------------------------------------------------
                }

                else
                {

                    dict.Add(tweet.Id, tweet);
                    DataRow row = dt1.NewRow();

                    //row["Tweet Id"] = tweet.Id;
                    row["Tweeted Text"] = tweet.Text;
                    row["Tweeted Around"] = Convert.ToDateTime(tweet.Stamp);
                    dt1.Rows.Add(row);
                    val++;

                }
            }

            dt = (DataTable)ViewState["Table"];
            ViewState["count"] = val;
            dt.Merge(dt1);
            ViewState["Table"] = dt;
            Cache["Table_Values"] = ViewState["Table"];

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
    }

When you load the application please press Ctrl and F5 to launch the application on your local machine.
If a warning comes up about the SSL certificate please trust it by selecting yes and also select yes when the second warning window comes up.
The only time you may want to change the code is if you would like to use the Dummy data. 
For this however the code is already written but commented out. 

To use Dummy data

There is a variable called "DummyData", this is test dummy data downloaded from google and saved in a file named tempdata.txt 
If you wish to use this please uncomment and replace the File path to where you have saved the file that came with the project.
for e.g @"C:\Users\ali\Downloads\tempdata.txt", this is where my file sits. 
Then uncomment "tempData = DummyData" in the SearchRes method.

Once done, you will need to comment out the the next 8 lines which set the tempdata. So it should look like this:
//-------------------------
//WebRequest webRequest = WebRequest.Create("https://www.google.co.uk/search?num=100&q=land+registry+search");
///WebResponse webResponse = webRequest.GetResponse();

///using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
///{
///    string siteSource = responseReader.ReadToEnd();
///    tempdata = siteSource;
///}
//--------------------------

If you would like to go back to live data then please revers what you did. 

Thank you 


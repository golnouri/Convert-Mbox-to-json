using mBoxProject;
using System.Text.Json;

Console.ForegroundColor = ConsoleColor.Green;
Console.Title = "JTD";
Console.WriteLine("JTD.IR");
Console.WriteLine("Convertor (.mbox) file to (JSON)");

Main main = new Main();
var dbmodel = main.ExtractEmailAddresses();

List<MailModel> mailModels = new List<MailModel>();
int counter = 0;
foreach(var email in dbmodel)
{
    counter++;
    MailModel mailModel = new MailModel { id = counter, email_address = email, regdate = DateTime.Now };
    mailModels.Add(mailModel);
}

var dbModel_Result = mailModels.ToList();

Console.WriteLine("Result:");
Console.WriteLine("\n");

Console.ForegroundColor = ConsoleColor.White;
foreach (var mailModel in dbModel_Result)
{
    Console.WriteLine("[" + mailModel.id + "] " +  mailModel.email_address);
    Thread.Sleep(40);
}

Console.WriteLine("\n");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("[.mBox] It is in drive (C)");
Console.WriteLine("JSON save? Y/N");

Console.ForegroundColor = ConsoleColor.Red;
string res = Console.ReadLine();
if(res == "y")
{
    string jsonString = JsonSerializer.Serialize(dbModel_Result);
    File.WriteAllText(@"E:\FileEmail.json", jsonString);

}

Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("OK! save in drive E.");

Console.ReadLine();
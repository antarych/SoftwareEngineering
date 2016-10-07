using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace WaybillNamespace
{
    public class Waybill
    {
        StreamReader file = new StreamReader(@"C:\nakladnaya_za_sentyabr.bill");

        public int LineCounter(StreamReader file)
        {
            int counter = 0;
            string line;           
            while ((line = file.ReadLine()) != null)
            {
                counter++;
            }
            file.BaseStream.Position = 0;
            return counter;
        }

        public string[] LineReader(StreamReader file)
        {
            int count = LineCounter(file);
            string[] linesWithHead = new string[count];
            string[] lines = new string[count - 1];
            for (int counter = 0; counter < count; counter++)
            {
                linesWithHead[counter] += file.ReadLine();
            }
            int j = 0;
            for (int i = 1; i < count; i++)
            {
                lines[j] = linesWithHead[i].Trim();
                j++;
            }
            file.BaseStream.Position = 0;
            return lines;
        }

        public string[] LineParser(string line)
        {
            string[] columns = line.Split('|');
            return columns;
        }

        public string WeightCheck(StreamReader file, long AllowedWeight)
        {
            string[] lines = LineReader(file);
            long sumWeight = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] columns = LineParser(lines[i]);
                sumWeight = +int.Parse(columns[4]);
            }
            if (sumWeight <= AllowedWeight) return "Допустимая масса";
            else return "Масса превышает допустимую";
        }

        public int TotalAmountCalculation(StreamReader file)
        {
            int inTotal = 0;
            string[] lines = LineReader(file);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] columns = LineParser(lines[i]);
                inTotal += int.Parse(columns[4]);
            }
            return inTotal;
        }

        public bool SendEmail(StreamReader file, string email)
        {
            MailAddress from = new MailAddress("lizardia@mail.ru");
            MailAddress to = new MailAddress(email);
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "Waybill";
            mail.Body = WeightCheck(file, 34567890) + ",  сумма: " + TotalAmountCalculation(file).ToString();
            SmtpClient client = new SmtpClient("smtp.mail.ru", 25);
            client.Credentials = new NetworkCredential("lizardia@mail.ru", "thisisMail10");
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.InnerException.Message.ToString());
                return false;
            }
            return true;
        }
    }
}

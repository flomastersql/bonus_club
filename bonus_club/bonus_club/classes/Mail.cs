using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Data;

namespace bonus_club
{
    class Mail
    {

        public static void send_alarm_msg()
        {
            string msg = "";

            foreach(DataRow row in Grafana_DB_Methods.get_cards_by_day().Rows) {
                msg += Grafana_DB_Methods.message_data(row["id_guest_card"].ToString()) + "<br>";
            }

            if (msg == "") { msg = "<b>За прошедшее число двойного использования приложения не зафиксированно.</b>";  }

            
            send_mail("Бонусный Клуб Аларм ", msg, "Andrei.Sorokin@goodfood-dv.ru");
            send_mail("Бонусный Клуб Аларм ", msg, "sb@goodfood-dv.ru");


//            select ROW_NUMBER() over(order by rk_check_num) + 2, r.name + ', Сумма: ' + CONVERT(varchar, check_sum)
//              + ', Дата: ' + CONVERT(varchar, order_date, 101) + ' ' + CONVERT(varchar, order_date, 108)
//, *from[westrest_orders] wo join restaurants r on wo.id_rest = r.id
//where wo.id_guest_card = 42401А

        }

        static void send_mail(string subj, string body, string mail_to)
        {

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("info@goodfood-dv.ru");
            // кому отправляем
            MailAddress to = new MailAddress(mail_to);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = subj;
            // текст письма
            m.Body = body;
            // письмо представляет код html
            m.IsBodyHtml = true;
            //// адрес smtp-сервера и порт, с которого будем отправлять письмо ПАРАМЕТРЫ ДЛЯ DCMOS
            //SmtpClient smtp = new SmtpClient("m.goodfood-dv.ru", 587);
            //// логин и пароль
            //smtp.Credentials = new NetworkCredential(@"dcmos\a.sorokin", "xqBSUdZs");
            //smtp.EnableSsl = true;
            SmtpClient smtp = new SmtpClient("mb.goodfood-dv.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(@"PRIMINVESTOR\info", "Efo5By5uir");
            //smtp.EnableSsl = true;
            smtp.Send(m);

            Thread.Sleep(1000);
            
        }
    }
}

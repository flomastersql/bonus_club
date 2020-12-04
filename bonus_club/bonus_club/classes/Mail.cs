using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace bonus_club
{
    class Mail
    {

        public static void send_alarm_msg(string card_id)
        {
            Mail.send_mail("GGGG", "<h2>GGGGGG</h2>", "Andrei.Sorokin@goodfood-dv.ru");


//            select ROW_NUMBER() over(order by rk_check_num) + 2, r.name + ', Сумма: ' + CONVERT(varchar, check_sum)
//              + ', Дата: ' + CONVERT(varchar, order_date, 101) + ' ' + CONVERT(varchar, order_date, 108)
//, *from[westrest_orders] wo join restaurants r on wo.id_rest = r.id
//where wo.id_guest_card = 42401

        }

        static void send_mail(string subj, string body, string mail_to)
        {

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("Andrei.Sorokin@goodfood-dv.ru");
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
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("m.goodfood-dv.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(@"dcmos\a.sorokin", "xqBSUdZs");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etq_lote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lote.Text = GetLote();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string getLote = GetLote();
            // Cadena ZPL de ejemplo
            //string zplData = $"^XA^FO20,20^ADN,36,20^FD{getLote}^FS^XZ";
            //string zplData = $"^XA\r\n~TA000\r\n~JSN\r\n^LT0\r\n^MNW\r\n^MTT\r\n^PON\r\n^PMN\r\n^LH0,0\r\n^JMA\r\n^PR6,6\r\n~SD15\r\n^JUS\r\n^LRN\r\n^CI27\r\n^PA0,1,1,0\r\n^XZ\r\n^XA\r\n^MMT\r\n^PW812\r\n^LL609\r\n^LS0\r\n^FO32,47^GFA,265,640,16,:Z64:eJzV0TEOwiAUBuC/6VC33kCu4WDkYrXUODh6pWcYeo0SBtYmLh1Mnw/QtHFyMhEG8oXw8x4A/zXKEWqWdVNUFF0/oLgDdlW2bCZPKltH0+KD/vAW6kq6ZBOoRYsG0caKb3zirpliHnuxZcvdMd5XvB3IxPzyPkpeH/yAZOuSrZ/Q6sVyCo2CuviXneSvPRjar0yoKNXrc753PaV+HA+s5P4+UOqXZKpcX34PJlNL/Wfu4nsxNHQV+5t/+1lfjCd4s56G:954F\r\n^FO46,83^GFA,185,480,12,:Z64:eJxjYBgEwI75B5xdx/4Hzv7H/w/GZPwn/x+JLQ9jM4PYjD/ACtn3AdnMEE3sdkCK/T+YzQdi80PYciC2/PyGGiDbxg5opjx/A8hyCzt7+QYou/7/Pn4gu/EDgt38AMFuh7D3A9XPbz8AZs//DzOfAWQmO9ThYDfA2EA/Qt1JTwAA3IA/8g==:202B\r\n^FO197,47^GFA,653,3216,48,:Z64:eJzt1Ttu3DAQBmASLFTyBAGvkNZFzIsFIoEtUvoIuYqMLXwNGi7SJVykYWCCkxk+dimFUZxUKcRdQKP5vy20fIixYxzjGG8eifFIV7UM4xJ298BEYjNjxjNtDQQAy4FqZUWYfA7lk5++QyI/wSLBoofAzNI81eij9DkceA6x83Hjz356KV6CU7DMTKx8uvocdl6B0+DIp6HP4cqX1rTvg6xek/fkgYFrnmr0SZVQPgZ5rv7Jmwdq+bEvYedPwUzUcoa9Ohbxw3iguvqpeZ/nS4swC2ot7zuvr76EN2+4S/gT9Iy/+qvHuvgSPkZV/cxZ5NhSI//1nc+hXKI6Vc+qt9Xjs179tw+dh7j1l85f/uRPIC6heYP1X3iArZ+12PPp3/yXu13vOu+y/7HnJxebj1iv/P39wEOs84Ue1l7juljP78qHHe/qetCdd7/1RoS63rTEFV7XD27rhP7l4lv4UWzX89jXUMWbb/tl6EvY+U+05Qzgfiye9mPxcCafQ/Ld+YAt3O8K//rmFd2Sz+HWu+IXffOLbt6Rl0H051XxtvOW/PPzL76chwYEPeDA57Dz+bzFFqcJGng58pZ8oCO/eaw/V2/J44ugeAFWADP4dUOfw87f3kf2Te+jYxzjfx4/Afu2G5s=:4E76\r\n^FO585,87^GFA,361,864,24,:Z64:eJzl0TFqxTAMBmCZDB59gQe6yMO+VqEmCbwh4ztCr+LQoWOv4JIDVOEtDgSrspK2ZyjV+Bkk6xfA/ypLls0OFaCHMIbC1VJz3C1b7ng0PA65Oe7Nw+7YycvYceI8iAf13ovfp7fULR8rNe9986t3o3PTlOwsHgHiVR28A7Tvt2zndaUngAKHRxd//TkbgtjY7FhPJ85MXTY61xTkwxcaEhfxol4RX8Q/H7wyld0mU7V/AKe+svSHaJOILnw6bY9c5BejiNTlx83pF/WI3t1139clbyQe1X0IqDnYZVm3UpyIjq0oqd04dTwzcUGRI2dXv3OWPAnhyNlSV467VLkLJoTjLn+9vgCcZ7m5:BBDA\r\n^FO599,47^GFA,297,720,20,:Z64:eJzd0aFuxDAMBmBXAYZ+g/OLTMlrDVhtpgN9qanLdKBwr1B2NDAgquek1xscnDQzf8C/ZQP8jwq3Kph21IxvWikPuZunq86aySwUV7oxz83YbKpPw3XVHMxkxNqNFpyT2zRCKb7bvdJO1w0/NQ7Z7L2ZYDWzhOg2GGkB8HdxzXj4iphATivdyGyodPkxDxQpusJspse8wzB3G6XnihkDpWArNVuexvFh/IFrOizAwwLPa3o1u8C0T5rAi7S7pGLmzexw4F9E8KbxMD2tuG2H06z56zf/Wt9JCpsO:CCF6\r\n^FO100,257^GFA,277,480,12,:Z64:eJzFkD1uwzAMRmVk0Ogj8CbWxT47Ajp0CdAj+CoMMmgJmiM0RoB6SyQI8A9qhKHb5gothw9vIIlHGvP/ZZn8YbLsfGMoOg4LxS2LcXHbne4uSifeTdK9iWYWX01zattqnnPPqFPXkuYYPOpY/DAb1PnFE1CM78rjwVTApv9QlotpANuL9ks2C1AG0T1fuZgAer2tO8dNBJwNKw/2DDRPZuhwYHUYSqnUp2e1+ix/3dT8SkJJ0sru+M1R1ht3JHYvsfnT3z4A1paRbw==:8721\r\n^FO32,257^GFA,133,320,8,:Z64:eJxjYKANsP9/gDiagf9A3Z8PQJr9wZ//f4DizR9//P8HpBt/f4DQ/z/8qwfSDf8f/LEH0fUHQDQDA4yGiMPo/wd/Q9Qf/g0x5zDUvONQ88+D7QODPwyk0VgAAHGjVro=:CBD2\r\n^FO270,188^GFA,537,1944,36,:Z64:eJzt0jFuwzAMBVAFGriVNyhvEl8siBVo8Jgj+CoONHjMEeogg0c76BAHdcVSVFwURccuRcNJsJ9hfZLGPOo/VsHG2E4O6+XJ9stb+rvG/JZZRdu7abNeTSamT7bGzuTH0t06qFdRDbAdOjEQLTtuxGAkf+HmbaIXYDXInpNBBj5wJ4YY/Zk7nuTAbjGjGvxm5uJuInFQQ7yvzjyKKXjf9jwmQ/LzZKpwmZKp996/qsGqbU9itgVVagCyKfDYwGkS8yTmcBhnMQBqDIYumTUcZ2iSMVS1jZX/b8hgNuWn4bth3zrKplRjeTEtt2qA/eBYjdU7S/bFhLshMT4bvJt+MQ332Rz9YG/Z9Gok+2IwmwJ3A5zU5OyGUvZ5luyt7SV7Gde4YziIkf5ANhgu0i/pYe3P0kMxJCak3heE2aRZJMO1zqKMBbsI6c7LLD7NMtOfjGTnrvxqSIxNJu1GNtcwNGXaMdAdEzO4jX0Xgy94VWPDuXfPaVdXuqtlhKrZmFH6AbUNnXnUH6sPB3CLCg==:DE0A\r\n^FT620,297^BXN,9,200,14,14,1,_,1\r\n^FH\\^FD4176MX111D^FS\r\n^FO81,328^GFA,973,21336,84,:Z64:eJzt2zFu2zAUBuBHaNBWXqAAr9EpvJghufCQa8nIkLFXYNELsFNZlOXr/2zXitxFMlKgQf+HxCJp8nMkk3xcovrKMYm8NkmT5r9uXsIfkh7zTorTQ+onX0N5wEvfBG0P/qASc5dO7+qEan+89BOrphIx9jZo0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJ8y7zb/xvNU2a/5vJYLy1KCJ9ljDhkmRs0qQr4tOpilato+Yui7iyyQxVRowKBWane98klnM1n01kIkG2Whv28bGJ4jKCbr1OQa0osVrryUQHQeva6AxTp0Bw49q8pqh7bVZFqzubauZ+rdnPpi5N1a60sznCjOtNPDVp8VCA1BFmeM5jOKIoNR7ycDLTEPcS7WtcFyPMGjBaXI1SxYr+WCIetBXtcfdTC3sZ/WpTZ7PcmP5i+n2FOaw3f2IQRqcHkQ8RQnB51x9zuJg2M4O8h/luvfm92OjnFFE2E7+1/5LDHq1Pv02BKevNzy/Mwf1IL81jqd23SXAL9q656+LjwtQymzVMWjrNMmw13Wx2NsOvJmbYFFOH73Anztbl+nX00swLE1lxzGbW8/5R7zJxp202Rz1q7bHA0MO8TXvI1WxYjAsTxa/Veth9r1+bbjGX0jibQW0uTc3lrXNpYeJnNv2nU+t5it5tYuQLU/xsmtenVzTTfeYj1rvL4ZBg5to/Yb0DekyxnwZYBeZuk3nZl7ocgFz3JdmZ6c10Zta7zBIf8zCb1T7CJ1i2TKX5TeZ5n3d1xPyc9/kWuzxgfuLva9jnx/X7vLvmI4cEtMhxlo+wjnDfqrYE7jCRjHC5yZtY7zA35rhlftdyk98dDgyTbMzvbj6HRDt4/HEOSTDRQfy2c8jlvORPB6Sb81Lcw0SH0+GCwWC8nfgF2q7I/w==:332C\r\n^FT32,229^A0N,28,28^FH\\^CI28^FD{getLote}^FS^CI27\r\n^PQ1,0,1,Y\r\n^XZ";
            string zplData = $"^XA\r\n~TA000\r\n~JSN\r\n^LT0\r\n^MNW\r\n^MTT\r\n^PON\r\n^PMN\r\n^LH0,0\r\n^JMA\r\n^PR6,6\r\n~SD15\r\n^JUS\r\n^LRN\r\n^CI27\r\n^PA0,1,1,0\r\n^XZ\r\n^XA\r\n^MMT\r\n^PW812\r\n^LL609\r\n^LS0\r\n^FO32,47^GFA,265,640,16,:Z64:eJzV0TEOwiAUBuC/6VC33kCu4WDkYrXUODh6pWcYeo0SBtYmLh1Mnw/QtHFyMhEG8oXw8x4A/zXKEWqWdVNUFF0/oLgDdlW2bCZPKltH0+KD/vAW6kq6ZBOoRYsG0caKb3zirpliHnuxZcvdMd5XvB3IxPzyPkpeH/yAZOuSrZ/Q6sVyCo2CuviXneSvPRjar0yoKNXrc753PaV+HA+s5P4+UOqXZKpcX34PJlNL/Wfu4nsxNHQV+5t/+1lfjCd4s56G:954F\r\n^FO46,83^GFA,185,480,12,:Z64:eJxjYBgEwI75B5xdx/4Hzv7H/w/GZPwn/x+JLQ9jM4PYjD/ACtn3AdnMEE3sdkCK/T+YzQdi80PYciC2/PyGGiDbxg5opjx/A8hyCzt7+QYou/7/Pn4gu/EDgt38AMFuh7D3A9XPbz8AZs//DzOfAWQmO9ThYDfA2EA/Qt1JTwAA3IA/8g==:202B\r\n^FO197,47^GFA,653,3216,48,:Z64:eJzt1Ttu3DAQBmASLFTyBAGvkNZFzIsFIoEtUvoIuYqMLXwNGi7SJVykYWCCkxk+dimFUZxUKcRdQKP5vy20fIixYxzjGG8eifFIV7UM4xJ298BEYjNjxjNtDQQAy4FqZUWYfA7lk5++QyI/wSLBoofAzNI81eij9DkceA6x83Hjz356KV6CU7DMTKx8uvocdl6B0+DIp6HP4cqX1rTvg6xek/fkgYFrnmr0SZVQPgZ5rv7Jmwdq+bEvYedPwUzUcoa9Ohbxw3iguvqpeZ/nS4swC2ot7zuvr76EN2+4S/gT9Iy/+qvHuvgSPkZV/cxZ5NhSI//1nc+hXKI6Vc+qt9Xjs179tw+dh7j1l85f/uRPIC6heYP1X3iArZ+12PPp3/yXu13vOu+y/7HnJxebj1iv/P39wEOs84Ue1l7juljP78qHHe/qetCdd7/1RoS63rTEFV7XD27rhP7l4lv4UWzX89jXUMWbb/tl6EvY+U+05Qzgfiye9mPxcCafQ/Ld+YAt3O8K//rmFd2Sz+HWu+IXffOLbt6Rl0H051XxtvOW/PPzL76chwYEPeDA57Dz+bzFFqcJGng58pZ8oCO/eaw/V2/J44ugeAFWADP4dUOfw87f3kf2Te+jYxzjfx4/Afu2G5s=:4E76\r\n^FO585,87^GFA,361,864,24,:Z64:eJzl0TFqxTAMBmCZDB59gQe6yMO+VqEmCbwh4ztCr+LQoWOv4JIDVOEtDgSrspK2ZyjV+Bkk6xfA/ypLls0OFaCHMIbC1VJz3C1b7ng0PA65Oe7Nw+7YycvYceI8iAf13ovfp7fULR8rNe9986t3o3PTlOwsHgHiVR28A7Tvt2zndaUngAKHRxd//TkbgtjY7FhPJ85MXTY61xTkwxcaEhfxol4RX8Q/H7wyld0mU7V/AKe+svSHaJOILnw6bY9c5BejiNTlx83pF/WI3t1139clbyQe1X0IqDnYZVm3UpyIjq0oqd04dTwzcUGRI2dXv3OWPAnhyNlSV467VLkLJoTjLn+9vgCcZ7m5:BBDA\r\n^FO599,47^GFA,297,720,20,:Z64:eJzd0aFuxDAMBmBXAYZ+g/OLTMlrDVhtpgN9qanLdKBwr1B2NDAgquek1xscnDQzf8C/ZQP8jwq3Kph21IxvWikPuZunq86aySwUV7oxz83YbKpPw3XVHMxkxNqNFpyT2zRCKb7bvdJO1w0/NQ7Z7L2ZYDWzhOg2GGkB8HdxzXj4iphATivdyGyodPkxDxQpusJspse8wzB3G6XnihkDpWArNVuexvFh/IFrOizAwwLPa3o1u8C0T5rAi7S7pGLmzexw4F9E8KbxMD2tuG2H06z56zf/Wt9JCpsO:CCF6\r\n^FO100,272^GFA,277,480,12,:Z64:eJzFkD1uwzAMRmVk0Ogj8CbWxT47Ajp0CdAj+CoMMmgJmiM0RoB6SyQI8A9qhKHb5gothw9vIIlHGvP/ZZn8YbLsfGMoOg4LxS2LcXHbne4uSifeTdK9iWYWX01zattqnnPPqFPXkuYYPOpY/DAb1PnFE1CM78rjwVTApv9QlotpANuL9ks2C1AG0T1fuZgAer2tO8dNBJwNKw/2DDRPZuhwYHUYSqnUp2e1+ix/3dT8SkJJ0sru+M1R1ht3JHYvsfnT3z4A1paRbw==:8721\r\n^FO32,272^GFA,133,320,8,:Z64:eJxjYKANsP9/gDiagf9A3Z8PQJr9wZ//f4DizR9//P8HpBt/f4DQ/z/8qwfSDf8f/LEH0fUHQDQDA4yGiMPo/wd/Q9Qf/g0x5zDUvONQ88+D7QODPwyk0VgAAHGjVro=:CBD2\r\n^FO269,171^GFA,537,1944,36,:Z64:eJzt0jFuwzAMBVAFGriVNyhvEl8siBVo8Jgj+CoONHjMEeogg0c76BAHdcVSVFwURccuRcNJsJ9hfZLGPOo/VsHG2E4O6+XJ9stb+rvG/JZZRdu7abNeTSamT7bGzuTH0t06qFdRDbAdOjEQLTtuxGAkf+HmbaIXYDXInpNBBj5wJ4YY/Zk7nuTAbjGjGvxm5uJuInFQQ7yvzjyKKXjf9jwmQ/LzZKpwmZKp996/qsGqbU9itgVVagCyKfDYwGkS8yTmcBhnMQBqDIYumTUcZ2iSMVS1jZX/b8hgNuWn4bth3zrKplRjeTEtt2qA/eBYjdU7S/bFhLshMT4bvJt+MQ332Rz9YG/Z9Gok+2IwmwJ3A5zU5OyGUvZ5luyt7SV7Gde4YziIkf5ANhgu0i/pYe3P0kMxJCak3heE2aRZJMO1zqKMBbsI6c7LLD7NMtOfjGTnrvxqSIxNJu1GNtcwNGXaMdAdEzO4jX0Xgy94VWPDuXfPaVdXuqtlhKrZmFH6AbUNnXnUH6sPB3CLCg==:DE0A\r\n^FT620,297^BXN,9,200,14,14,1,_,1\r\n^FH\\^FD4176MX111D^FS\r\n^FO81,328^GFA,973,21336,84,:Z64:eJzt2zFu2zAUBuBHaNBWXqAAr9EpvJghufCQa8nIkLFXYNELsFNZlOXr/2zXitxFMlKgQf+HxCJp8nMkk3xcovrKMYm8NkmT5r9uXsIfkh7zTorTQ+onX0N5wEvfBG0P/qASc5dO7+qEan+89BOrphIx9jZo0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJkyZNmjRp0qRJ8y7zb/xvNU2a/5vJYLy1KCJ9ljDhkmRs0qQr4tOpilato+Yui7iyyQxVRowKBWane98klnM1n01kIkG2Whv28bGJ4jKCbr1OQa0osVrryUQHQeva6AxTp0Bw49q8pqh7bVZFqzubauZ+rdnPpi5N1a60sznCjOtNPDVp8VCA1BFmeM5jOKIoNR7ycDLTEPcS7WtcFyPMGjBaXI1SxYr+WCIetBXtcfdTC3sZ/WpTZ7PcmP5i+n2FOaw3f2IQRqcHkQ8RQnB51x9zuJg2M4O8h/luvfm92OjnFFE2E7+1/5LDHq1Pv02BKevNzy/Mwf1IL81jqd23SXAL9q656+LjwtQymzVMWjrNMmw13Wx2NsOvJmbYFFOH73Anztbl+nX00swLE1lxzGbW8/5R7zJxp202Rz1q7bHA0MO8TXvI1WxYjAsTxa/Veth9r1+bbjGX0jibQW0uTc3lrXNpYeJnNv2nU+t5it5tYuQLU/xsmtenVzTTfeYj1rvL4ZBg5to/Yb0DekyxnwZYBeZuk3nZl7ocgFz3JdmZ6c10Zta7zBIf8zCb1T7CJ1i2TKX5TeZ5n3d1xPyc9/kWuzxgfuLva9jnx/X7vLvmI4cEtMhxlo+wjnDfqrYE7jCRjHC5yZtY7zA35rhlftdyk98dDgyTbMzvbj6HRDt4/HEOSTDRQfy2c8jlvORPB6Sb81Lcw0SH0+GCwWC8nfgF2q7I/w==:332C\r\n^FT32,253^A0N,28,28^FH\\^CI28^FD{getLote}^FS^CI27\r\n^PQ1,0,1,Y\r\n^XZ";

            // Crear un Socket TCP/IP 
            TcpClient tcpSocket = new TcpClient(ip.Text, int.Parse(port.Text));

            // Convertir la cadena ZPL a bytes
            byte[] sendBytes = Encoding.Default.GetBytes(zplData);

            // Obtener el stream de red y escribir los bytes
            NetworkStream networkStream = tcpSocket.GetStream();
            networkStream.Write(sendBytes, 0, sendBytes.Length);

            // Cerrar la conexión
            networkStream.Close();
            tcpSocket.Close();

            //Actualizar el lote en la imagen de la etiqueta
            lote.Text = getLote;
        }

        public string GetLote()
        {
            int n1 = 0, n2 = 1, sum = 0;

            for (int i = 0; i < 50; i++)
            {
                //Console.WriteLine(n1);
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;
            }


            Console.WriteLine("Estructura del lote: ");
            DateTime dateTime = DateTime.Now;

            var getYear = dateTime.Year.ToString();
            var year = getYear.LastOrDefault();
            var day = dateTime.DayOfYear.ToString();
            var hour = dateTime.Hour.ToString("D2");
            var minute = dateTime.Minute.ToString("D2");

            var turno = dateTime.Hour.ToString();

            DateTime startT1 = DateTime.Now, endT1 = DateTime.Now, startT2 = DateTime.Now, endT2 = DateTime.Now, startT3 = DateTime.Now, endT3 = DateTime.Now;
            //Turno 1
            startT1 = DateTime.Parse("6:00 AM");
            endT1 = DateTime.Parse("2:00 PM");
            startT2 = DateTime.Parse("2:00 PM");
            endT2 = DateTime.Parse("10:00 PM");
            startT3 = DateTime.Parse("10:00 PM");
            endT3 = DateTime.Parse("6:00 AM");

            int t = 0;

            if ((dateTime >= startT1) && (dateTime <= endT1))
            {
                t = 1;
            }
            else if ((dateTime >= startT2) && (dateTime <= endT2))
            {
                t = 2;
            }
            else if ((dateTime >= startT3) && (dateTime <= endT3))
            {
                t = 3;
            }

            string lote = "";

            if (!string.IsNullOrEmpty(line.Text))
            {
                lote = $"LOT {year}{day}MX11{t}{line.Text} {hour}:{minute}";
            }
            else
            {
                lote = $"LOT {year}{day}MX11{t}[X] {hour}:{minute}";
            }

            return lote;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

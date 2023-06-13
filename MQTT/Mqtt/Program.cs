using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

/*
 MQTT -> MQTT(Message Queuing Telemetry Transport)
 Düşük bant genişliğine sahip  basit bir mesajlaşma protokolüdür.
 MQTT iletişimi bir publish ve subscribe sistemi olarak çalışır. 
 Cihazlar belirli bir konuda mesajlar yayınlar. 
 Veriler direk Broker üzerinden gönderilmez. 
 Bir Topic aracılığı ile gönderilir. 
 Buna abone olan tüm cihazlar mesajı alır. 

MQTT’de temel kavramLAR
Publish(Yayınlama) - Subscribe(Abone Olma)
Topics (Konular):yayınlanan mesajların yönlendirildiği konuları ifade eder.Konular, kesirli ("/") ayrılmış bir dize yapısına sahiptir 
Broker(Sunucu)mesajları yönlendirir ve iletimini sağlar.
Messages(Veriler) UTF-8 kodlamasıyla kodlanmış bir dize veya byte dizisi olarak gönderilir.

..........(QoS) Mesaj Gönderim Seviyesi...... 
MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE --> (bir kez iletme) 
MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE (en fazla bir kez iletme) 
MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE (en az bir kez iletme) bulunur.

..........Nuget.............
M2Mqtt Paketini kurmamız gerekir

namespaceleri
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
-

 */


#region  Mqtt ile (Publisher) veri gönderim işlemi 
namespace MqttPublish
{
    class Program
    {
        static void Main(string[] args)
        {
            //Baglantı işlemleri
            MqttClient mqttClient = new MqttClient("broker.hivemq.com");

            //clientId --> Random atadık 
            string clientId = Guid.NewGuid().ToString();
            mqttClient.Connect(clientId);

            //Mesaj içeriği
            Console.WriteLine("Gönderilecek Mesajınızı Giriniz: ");
            string message = Console.ReadLine();
            
            //Topic -> Yayn yapılacak işlem konusu
            //Yayınlama işlemi için Topic Bilgisi
            string Topic = "test/deneme";

            //Yayınlama İşlemi
            //Mesaj Byte Çevrilir
            //MqttMsgBase --> Mesaj Gönderim seviyesini ifade eder
            //Mesaj abone olan kişiye gönderilecek ve son veri iletilecektir.
            mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

        }
    }

}
#endregion
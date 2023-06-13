
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;


#region Mqtt ile (Subscribe) gelen veriyi almak ve işlemek için kullnılmıştır.
class Programm
{
  
    static void Main(string[] args)
    {
        //Baglantı işlemleri
        MqttClient mqttClient = new MqttClient("broker.hivemq.com");
        //Mesaj geldiğinde işlem tetikler 
        mqttClient.MqttMsgPublishReceived += client_recievedMessage;

        //clientId --> Random atadık 
        string clientId = Guid.NewGuid().ToString();
        mqttClient.Connect(clientId);

        //Yyaınlanan mesajı alma işlemi 
        //String[] { "test/deneme" } --> hangi konuya abone olacağını belirtiyoruz ,çokluda olabilir
        //MqttMsgBase --> Mesaj Gönderim seviyesini ifade eder
        //Mesaj abone olan kişiye gönderilecek ve son veri iletilecektir.
        mqttClient.Subscribe(new String[] { "test/deneme" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
    }

    /// <summary>
    /// Mesaj yayınlandığında tetiklenir
    /// </summary>
    /// <param name="sender"> Olayı tetikleyen (client)</param>
    /// <param name="e">e.Message baytlarını bir dizeye dönüştürür.
    /// gelen mesajı okunabilir bir metin formatına dönüştürmek için kullanılır.<br/></param>
    static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
    {
        var message = System.Text.Encoding.Default.GetString(e.Message);
        System.Console.WriteLine("Alınan Mesaj: " + message);
    }
}
#endregion
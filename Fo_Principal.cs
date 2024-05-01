using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Youtube.Video.Downloader
{
    public partial class Fo_Principal : Form
    {
        public IConfiguration _config;
        public Fo_Principal()
        {
            InitializeComponent();
            _config = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json")
                .Build();
        }
        private string LimparNomeParaArquivo(string nome)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                nome = nome.Replace(c, '_');
            }
            return nome;
        }
        private bool ExisteInformacaoNoGrid(string link)
        {
            foreach (DataGridViewRow row in Grid_musicas.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() == link)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private async void Btn_download_Click(object sender, EventArgs e)
        {
            string chaveapi = _config["ChaveApi:X-RapidAPI-Key"];
            string hostapi = _config["HostApi:X-RapidAPI-Host"];
            foreach (DataGridViewRow item in Grid_musicas.Rows)
            {
                string nome = item.Cells[1].Value.ToString();
                string _id_video = item.Cells[2].Value.ToString();
                string nome_limpo = LimparNomeParaArquivo(nome);
                string uri;
                var client = new HttpClient();
                if(hostapi == "youtube-mp3-downloader2.p.rapidapi.com")
                {
                     uri = ("https://youtube-mp3-downloader2.p.rapidapi.com/ytmp3/ytmp3/?url=" + _id_video);
                }
                else
                {
                     uri = ("https://youtube-mp3-download1.p.rapidapi.com/dl?id=" + _id_video);
                }
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,                                                                                
                    RequestUri = new Uri(uri),  
                    Headers =
                    {
                    { "X-RapidAPI-Key", chaveapi }, 
                    { "X-RapidAPI-Host", hostapi },    
                    },
                };
                try
                {
                    using var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var responsebody = await response.Content.ReadAsStringAsync();
                    dynamic jsonresponse = JsonConvert.DeserializeObject<dynamic>(responsebody);                    
                    if (hostapi == "youtube-mp3-downloader2.p.rapidapi.com")
                    {
                        string urlaudio = jsonresponse.dlink;
                        using var httpClient = new HttpClient();
                        {
                            var audiolink = await httpClient.GetByteArrayAsync(urlaudio);
                            if (!Directory.Exists("Musicas"))
                            {
                                Directory.CreateDirectory("Musicas");
                            }
                            using (var arquivoaudio = System.IO.File.Create("Musicas/" + nome_limpo + ".mp3"))
                            {
                                await arquivoaudio.WriteAsync(audiolink);
                            }
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(500);
                        //////USAR QUANDO FOR USAR OUTRA API ///////////////
                        var options = new ChromeOptions();
                        if (!Directory.Exists("Musicas"))
                        {
                            Directory.CreateDirectory("Musicas");
                        }
                        string diretoriodownload = @"C:\Users\Gabriel\Desktop\Projeto orçamento C#\Youtube.Video.Downloader\Musicas";
                        options.AddUserProfilePreference("download.default_directory", diretoriodownload);
                        string linkdownload = jsonresponse.link;
                        using (var driver = new ChromeDriver())
                        {
                            driver.Navigate().GoToUrl(linkdownload);
                            var dowloadbutton = driver.FindElement(By.ClassName("dlbtn"));
                            System.Threading.Thread.Sleep(1000);
                            dowloadbutton.Click();
                            System.Threading.Thread.Sleep(2500);
                        }
                        i = 0;
                    }
                }
                catch (HttpRequestException ex)
                {
                MessageBox.Show($"Erro na requisição HTTP: {ex.Message}");
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                }
            }
            MessageBox.Show("Downloads finalizados com sucesso!");
            Console.WriteLine("Downloads finalizados com sucesso!");
            Grid_musicas.Rows.Clear(); 
        }
        int i = 0;
        private async void btn_addlist_Click(object sender, EventArgs e)
        {
            string chaveapi = _config["ChaveApi:X-RapidAPI-Key"];
            string hostapi = _config["HostApi:X-RapidAPI-Host"];
            string link = txt_link.Text;
            if (txt_link.Text == "")
            {
                MessageBox.Show("Informe um link para poder incluir na lista!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cbx_playlist.Checked)
            {
                string quebrastring = "https://www.youtube.com/playlist?list=";
                string id_playlist = link.Replace(quebrastring, "");
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://youtube138.p.rapidapi.com/playlist/videos/?id=" + id_playlist + "&hl=en&gl=US"),
                    Headers =
                {
                  { "X-RapidAPI-Key", chaveapi },                                       
                  { "X-RapidAPI-Host", "youtube138.p.rapidapi.com" },      
                },
                };
                try
                {
                    using var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    dynamic jsonresponse = JsonConvert.DeserializeObject<dynamic>(body);
                    foreach (var item in jsonresponse.contents)
                    {
                        var id = item.index; 
                        string titulo = item.video.title;
                        string id_video = null;
                        if (hostapi == "youtube-mp3-download1.p.rapidapi.com")
                        {
                            id_video = item.video.videoId;
                        }
                        else
                        {
                            id_video = "https://www.youtube.com/watch?v=" + id_video;
                        }
                        var temp_segundos = Convert.ToDouble(item.video.lengthSeconds);
                        var minutos = TimeSpan.FromSeconds(temp_segundos);
                        Grid_musicas.Rows.Add(id, titulo, id_video, minutos);
                        txt_link.Text = null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Erro na requisição HTTP: {ex.Message}");
                    Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                }
            }
            else
            {
                if (ExisteInformacaoNoGrid(link) == true)
                {
                    MessageBox.Show("Link já existente na lista!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string quebrastring = "https://www.youtube.com/watch?v=";
                string id_video = link.Replace(quebrastring, "");
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://youtube138.p.rapidapi.com/video/details/?id=" + id_video + "&hl=en&gl=US"),
                    Headers =
                    {                                           
                        { "X-RapidAPI-Key", chaveapi }, 
                        { "X-RapidAPI-Host", "youtube138.p.rapidapi.com" },
                    },
                };
                try
                {
                    using var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    dynamic jsonresponse = JsonConvert.DeserializeObject<dynamic>(body);
                    i++;
                    string titulo = jsonresponse.title;
                    var temp_segundos = Convert.ToDouble(jsonresponse.lengthSeconds);
                    var minutos = TimeSpan.FromSeconds(temp_segundos);
                    Grid_musicas.Rows.Add(i, titulo, id_video, minutos);
                    txt_link.Text = null;
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Erro na requisição HTTP: {ex.Message}");
                    Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                }
            }
        }
    }
}
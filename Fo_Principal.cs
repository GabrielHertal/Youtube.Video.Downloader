using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Security.Cryptography.X509Certificates;

namespace Youtube.Video.Downloader
{
    public partial class Fo_Principal : Form
    {
        public IConfiguration _config;
        public string chaveapi;
        public string hostapi;
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
                nome = nome.Replace(c, '-');
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
            ///////////////////////////Verifica qual a chave da API esta selecionada//////////////////////////////////
            if (cbx_chave.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma ChaveAPI", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cbx_chave.SelectedIndex == 0)
            {
                chaveapi = _config["ChaveApi:X-RapidAPI-Key1"];
            }
            else if (cbx_chave.SelectedIndex == 1)
            {
                chaveapi = _config["ChaveApi:X-RapidAPI-Key2"];
            }
            else
            {
                chaveapi = _config["ChaveApi:X-RapidAPI-Key3"];
            }
            ///////////////////////////Verifica qual a Host da API esta selecionada//////////////////////////////////
            if (cbx_host.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um HostAPI!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cbx_host.SelectedIndex == 0)
            {
                hostapi = _config["HostApi:X-RapidAPI-Host1"];
            }
            else
            {
                hostapi = _config["HostApi:X-RapidAPI-Host2"];
            }
            foreach (DataGridViewRow item in Grid_musicas.Rows)
            {
                string nome = item.Cells[1].Value.ToString();
                string _id_video = item.Cells[2].Value.ToString();
                string nome_limpo = LimparNomeParaArquivo(nome);
                string uri;
                var client = new HttpClient();
                //////////Verifica qual a chave da API e dependendo altera a URI que faz a requisição///////////////
                if (hostapi == "youtube-mp3-downloader2.p.rapidapi.com")
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
                    /////////////////Verifica qual a chave da API e qual ação deve fazer///////////////
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
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                    }
                    //////////////////API que faz o download do video abrindo o Chrome e clicando no botão////////////////////////
                    else
                    {
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
                            System.Threading.Thread.Sleep(1500);
                            dowloadbutton.Click();
                            System.Threading.Thread.Sleep(2500);
                        }
                        i = 0;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Erro na requisição: {ex.Message}");
                    Console.WriteLine($"Erro na requisição: {ex.Message}");
                    return;
                }
            }
            MessageBox.Show("Downloads finalizados com sucesso!");
            Console.WriteLine("Downloads finalizados com sucesso!");
            Grid_musicas.Rows.Clear();
        }
        int i = 0;
        private async void btn_addlist_Click(object sender, EventArgs e)
        {
            ///////////////////////////Verifica qual a chave da API esta selecionada//////////////////////////////////
            if (cbx_chave.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma ChaveAPI", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cbx_chave.SelectedIndex == 0)
            {
                chaveapi = _config["ChaveApi:X-RapidAPI-Key1"];
            }
            else if (cbx_chave.SelectedIndex == 1)
            {
                chaveapi = _config["ChaveApi:X-RapidAPI-Key2"];
            }
            else
            {
                chaveapi = _config["ChaveApi:X-RapidAPI-Key3"];
            }
            ///////////////////////////Verifica qual a Host da API esta selecionada//////////////////////////////////
            if (cbx_host.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um HostAPI!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cbx_host.SelectedIndex == 0)
            {
                hostapi = _config["HostApi:X-RapidAPI-Host1"];
            }
            else
            {
                hostapi = _config["HostApi:X-RapidAPI-Host2"];
            }
            string link = txt_link.Text;
            if (txt_link.Text == "")
            {
                MessageBox.Show("Informe um link para poder incluir na lista!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ///////////////////////////////////////Verifica se é uma playlist///////////////////////////////////
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
                        string _id_video = item.video.videoId;
                        string id_video = null;
                        if (hostapi == "youtube-mp3-download1.p.rapidapi.com")
                        {
                            id_video = item.video.videoId;
                        }
                        //////////////////Monta link para o video e adiciona na lista////////////////////////////
                        else
                        {
                            id_video = "https://www.youtube.com/watch?v=" + _id_video;
                        }
                        var temp_segundos = Convert.ToDouble(item.video.lengthSeconds);
                        var minutos = TimeSpan.FromSeconds(temp_segundos);
                        Grid_musicas.Rows.Add(id, titulo, id_video, minutos);
                        txt_link.Text = null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Erro na requisição: {ex.Message}");
                    Console.WriteLine($"Erro na requisição: {ex.Message}");
                }
            }
            ////////////////////////////////////Caso não seja uma playlist////////////////////////////////////////////////////////
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
                    MessageBox.Show($"Erro na requisição: {ex.Message}");
                    Console.WriteLine($"Erro na requisição: {ex.Message}");
                }
            }
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (Grid_musicas.SelectedCells.Count > 0)
            {
                foreach (DataGridViewRow row in Grid_musicas.SelectedRows)
                {
                    Grid_musicas.Rows.Remove(row);
                    i--;
                }
            }
        }
    }
}
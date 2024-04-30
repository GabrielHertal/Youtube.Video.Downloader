using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace Youtube.Video.Downloader
{
    public partial class Fo_Principal : Form
    {
        public Fo_Principal()
        {
            InitializeComponent();
        }
        private async void Btn_download_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://youtube-mp3-downloader2.p.rapidapi.com/ytmp3/ytmp3/?url=" + txt_link.Text),
                Headers =
                {
                    { "X-RapidAPI-Key", "4f84ec793amshcca1ecf872ad7f4p184291jsn3d3ee1b0cb1d" },
                    { "X-RapidAPI-Host", "youtube-mp3-downloader2.p.rapidapi.com" },
                },
            };
            try
            {
                using var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responsebody = await response.Content.ReadAsStringAsync();
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dynamic jsonresponse = JsonConvert.DeserializeObject<dynamic>(responsebody);
                string urlaudio = jsonresponse.dlink;
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                using var httpClient = new HttpClient();
                {
                    var audiolink = await httpClient.GetStreamAsync(urlaudio);

                    using (var arquivoaudio = File.Create("audio.mp3"))
                    {
                        await audiolink.CopyToAsync(arquivoaudio);
                    }
                }
                MessageBox.Show($"Sucesso na requisição!");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Erro na requisição HTTP: {ex.Message}");
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
            }
        }
        private async void Btn_addlist_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://youtube138.p.rapidapi.com/video/details/?id=" + txt_link.Text + "&hl=en&gl=US"),
                Headers =
                {
                  { "X-RapidAPI-Key", "4f84ec793amshcca1ecf872ad7f4p184291jsn3d3ee1b0cb1d" },
                  { "X-RapidAPI-Host", "youtube138.p.rapidapi.com" },
                },
            };
            try
            {
                using var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //////////////////Informações que são adicionadas ao DataGridView//////////////////
                string link = txt_link.Text;
                dynamic jsonresponse = JsonConvert.DeserializeObject<dynamic>(body);
                int i = 0; 
                i++;
                string titulo = jsonresponse.title;
                var temp_segundos = jsonresponse.lengthSeconds;
                Convert.ToDouble(temp_segundos);
                var minutos = TimeSpan.FromSeconds(temp_segundos);
                string datapublic = jsonresponse.publishedDate.ToString();
                Grid_musicas.Rows.Add(i, titulo, link, minutos);
                txt_link.Text = null;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Erro na requisição HTTP: {ex.Message}");
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
            }
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {

        }
    }
}
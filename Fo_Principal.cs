using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Youtube.Video.Downloader
{
    public partial class Fo_Principal : Form
    {
        public Fo_Principal()
        {
            InitializeComponent();
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
            foreach (DataGridViewRow item in Grid_musicas.Rows)
            {
                string nome = item.Cells[1].Value.ToString();
                string link = item.Cells[2].Value.ToString();
                string nome_limpo = LimparNomeParaArquivo(nome);
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://youtube-mp3-downloader2.p.rapidapi.com/ytmp3/ytmp3/?url=" + link + "&quality=320"),
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
                    dynamic jsonresponse = JsonConvert.DeserializeObject<dynamic>(responsebody);
                    string urlaudio = jsonresponse.dlink;
                    using var httpClient = new HttpClient();
                    {
                        var audiolink = await httpClient.GetStreamAsync(urlaudio);
                        if (!Directory.Exists("Musicas"))
                        {
                            Directory.CreateDirectory("Musicas");
                        }
                        using (var arquivoaudio = File.Create("Musicas/" + nome_limpo + ".mp3"))
                        {
                            await audiolink.CopyToAsync(arquivoaudio);
                        }
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
            string link = txt_link.Text;
            if (txt_link.Text == "")
            {
                MessageBox.Show("Informe um link para poder incluir na lista!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (ExisteInformacaoNoGrid(link) == true)
            {
                MessageBox.Show("Link já existente na lista!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://youtube138.p.rapidapi.com/video/details/?id=" + link + "&hl=en&gl=US"),
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
                dynamic jsonresponse = JsonConvert.DeserializeObject<dynamic>(body);
                i++;
                string titulo = jsonresponse.title;
                var temp_segundos = Convert.ToDouble(jsonresponse.lengthSeconds);
                var minutos = TimeSpan.FromSeconds(temp_segundos);
                Grid_musicas.Rows.Add(i, titulo, link, minutos);
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
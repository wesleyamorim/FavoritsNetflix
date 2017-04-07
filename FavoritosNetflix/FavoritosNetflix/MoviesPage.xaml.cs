using FavoritosNetflix.Models;
using FavoritosNetflix.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FavoritosNetflix
{
    public partial class MoviesPage : ContentPage
    {
        MovieService servico = new MovieService();
        List<Filme> filme = new List<Filme>();
        //public ObservableCollection<Filme> filme { get; set; }

        public MoviesPage()
        {
            InitializeComponent();
        }
        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //verifica a quantidade de caracteres digitados
            if (e.NewTextValue.Length > 5)
            {
                List<Movie> filmes = await servico.LocalizaFilmesPorAtor(e.NewTextValue);
                if (filmes == null || filmes.Count == 0)
                {
                    //esconde o listview e exibe o label
                    //exibe a mensagem no label
                    lvwMovies.IsVisible = false;
                    lblmsg.IsVisible = true;
                    lblmsg.Text = "Não foi possível retornar a lista de filmes";
                    lblmsg.TextColor = Color.Red;
                }
                else
                {
                    //exibe o listview e esconde o label 
                    //exibe a lista de filmes
                    lvwMovies.IsVisible = true;
                    lblmsg.IsVisible = false;
                    lvwlista.IsVisible = false;
                    lvwMovies.ItemsSource = filmes;
                }
            }
            else
            {
                //esconde o listview e exibe o label coma mensagem
                lvwMovies.IsVisible = false;
                lblmsg.IsVisible = true;
                lblmsg.Text = "Digite pelo menos 6 caracteres.";
            }
        }
        private void lvwMovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            //obtem o item selecionado
            var dilme = e.SelectedItem as Movie;
            //Cria uma lista da classe Filme
            
            //adiciona na lista o filme selecionado na pesquisa
            filme.Add(new Filme { Title = dilme.Title, ImageUrl = dilme.ImageUrl, ReleaseYear = dilme.ReleaseYear.ToString(), Summary = dilme.Summary });
            //adiciona na listview a lista de filmes
            lvwlista.ItemsSource = filme;
            //deseleciona o item do listview de pesquisa
            lvwMovies.SelectedItem = null;

            lvwlista.IsVisible = true;
            lvwMovies.IsVisible = false;
        }
    }
}

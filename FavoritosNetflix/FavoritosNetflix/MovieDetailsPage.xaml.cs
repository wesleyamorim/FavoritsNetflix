using FavoritosNetflix.Models;
using System;

using Xamarin.Forms;

namespace FavoritosNetflix
{
    public partial class MovieDetailsPage : ContentPage
    {
        public MovieDetailsPage(Movie filme)
        {
            //verifica se o objeto é null 
            //lança a exceção
            if (filme == null)
                throw new ArgumentNullException(nameof(filme));
            InitializeComponent();
            //vincula o filme ao BindingContext 
            //para fazer o databinding na view
            BindingContext = filme;
        }
    }
}

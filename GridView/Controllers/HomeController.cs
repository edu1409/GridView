using GridView.Models;
using GridView.Models.Classes;
using GridView.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchableGrid(string sort, bool asc, string filter, string search)
        {
            SearchableGridViewModel model = new ();
            IEnumerable<Product> products;

            search ??= filter;
            model.CurrentFilter = search;
            model.Action = nameof(SearchableGrid);

            //Listagem sem filtro ou reclassificação de lista filtrada
            if (search == filter)
            {
                if (string.IsNullOrWhiteSpace(filter)) //Listagem sem filtro
                {
                    products = DataService.GetProducts();
                }
                else //Reclassificação de lista filtrada
                {
                    products = DataService.GetProducts().
                        Where(p => p.Name.Contains(filter, StringComparison.InvariantCultureIgnoreCase)
                        || p.Classification.Contains(filter, StringComparison.InvariantCultureIgnoreCase));
                }
            }
            else //Nova pesquisa
            {
                products = DataService.GetProducts().
                    Where(p => p.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || p.Classification.Contains(search, StringComparison.InvariantCultureIgnoreCase));
            }

            //Define o model que será retornado para a view
            List<ProductViewModel> productList = new();

            foreach (var p in products)
            {
                productList.Add(new ProductViewModel
                {
                    Product = p.Name,
                    Category = p.Classification,
                    Price = p.Price
                });
            }

            //Classifica a lista de acordo com o campo selecionado
            switch (sort)
            {
                case nameof(ProductViewModel.Product):
                    productList = (asc ? productList.OrderBy(p => p.Product) : productList.OrderByDescending(p => p.Product)).ToList();
                    model.SortField = nameof(ProductViewModel.Product);
                    model.SortAscending = asc;
                    break;
                case nameof(ProductViewModel.Category):
                    productList = (asc ? productList.OrderBy(p => p.Category) : productList.OrderByDescending(p => p.Category)).ToList();
                    model.SortField = nameof(ProductViewModel.Category);
                    model.SortAscending = asc;
                    break;
                case nameof(ProductViewModel.Price):
                    productList = (asc ? productList.OrderBy(p => p.Price) : productList.OrderByDescending(p => p.Price)).ToList();
                    model.SortField = nameof(ProductViewModel.Price);
                    model.SortAscending = asc;
                    break;
                default: //ordem alfabética por ProductName
                    productList = (productList.OrderBy(p => p.Product)).ToList();
                    model.SortField = nameof(ProductViewModel.Product);
                    model.SortAscending = true;
                    break;
            }

            //Cria a lista classificada de acordo com o tipo compatível com a interface IGridViewItem
            SearchableList<IGridViewItem> sortedList = new();
            sortedList.AddRange(productList);

            model.List = sortedList;

            return View(model);
        }

        [HttpGet]
        public IActionResult PaginableGrid(int? page)
        {
            PaginableGridViewModel model = new();
            IEnumerable<Product> products = DataService.GetProducts();

            model.Action = nameof(PaginableGrid);

            //Define o model que será retornado para a view
            List<ProductViewModel> productList = new();

            foreach (var p in products)
            {
                productList.Add(new ProductViewModel
                {
                    Product = p.Name,
                    Category = p.Classification,
                    Price = p.Price
                });
            }

            //Obtém a página que será exibida na view
            int pageSize = 10;

            model.List = new PaginatedList<IGridViewItem>(productList, page ?? 1, pageSize);

            return View(model);
        }

        public IActionResult CompleteGrid(string sort, bool asc, string filter, string search, int? page)
        {
            CompleteGridViewModel model = new();
            IEnumerable<Product> products;

            search ??= filter;
            model.CurrentFilter = search;
            model.Action = nameof(CompleteGrid);

            //Listagem sem filtro ou reclassificação de lista filtrada
            if (search == filter)
            {
                if (string.IsNullOrWhiteSpace(filter)) //Listagem sem filtro
                {
                    products = DataService.GetProducts();
                }
                else //Reclassificação de lista filtrada
                {
                    products = DataService.GetProducts().
                        Where(p => p.Name.Contains(filter, StringComparison.InvariantCultureIgnoreCase)
                        || p.Classification.Contains(filter, StringComparison.InvariantCultureIgnoreCase));
                }
            }
            else //Nova pesquisa
            {
                page = 1;
                products = DataService.GetProducts().
                    Where(p => p.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || p.Classification.Contains(search, StringComparison.InvariantCultureIgnoreCase));
            }

            //Define o model que será retornado para a view
            List<ProductViewModel> productList = new();

            foreach (var p in products)
            {
                productList.Add(new ProductViewModel
                {
                    Product = p.Name,
                    Category = p.Classification,
                    Price = p.Price
                });
            }

            //Classifica a lista de acordo com o campo selecionado
            switch (sort)
            {
                case nameof(ProductViewModel.Product):
                    productList = (asc ? productList.OrderBy(p => p.Product) : productList.OrderByDescending(p => p.Product)).ToList();
                    model.SortField = nameof(ProductViewModel.Product);
                    model.SortAscending = asc;
                    break;
                case nameof(ProductViewModel.Category):
                    productList = (asc ? productList.OrderBy(p => p.Category) : productList.OrderByDescending(p => p.Category)).ToList();
                    model.SortField = nameof(ProductViewModel.Category);
                    model.SortAscending = asc;
                    break;
                case nameof(ProductViewModel.Price):
                    productList = (asc ? productList.OrderBy(p => p.Price) : productList.OrderByDescending(p => p.Price)).ToList();
                    model.SortField = nameof(ProductViewModel.Price);
                    model.SortAscending = asc;
                    break;
                default: //ordem alfabética por ProductName
                    productList = (productList.OrderBy(p => p.Product)).ToList();
                    model.SortField = nameof(ProductViewModel.Product);
                    model.SortAscending = true;
                    break;
            }

            //Obtém a página que será exibida na view
            int pageSize = 5;

            model.List = new PaginatedList<IGridViewItem>(productList, page ?? 1, pageSize);

            return View(model);
        }
    }
}

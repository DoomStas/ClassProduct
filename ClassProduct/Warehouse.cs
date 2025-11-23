using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    public class Warehouse
    {
        private string _title;
        private Product[] _products;
        private int _count;

        public Warehouse(string title, int capacity = 5)
        {
            _title = title;
            _products = new Product[capacity];
            _count = 0;
        }

        //Create
        public void AddProduct(Product product)
        {
            if (_count >= _products.Length)
            {
                Product[] newProducts = new Product[_products.Length * 2];
                for (int i = 0; i < _products.Length; i++)
                {
                    newProducts[i] = _products[i];
                }
                _products = newProducts;
            }
            _products[_count] = new Product(product);
            _count++;
        }
        //Read
        public Product this[int index]
            {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
                return new Product(_products[index]);
            }
        }
        //Update
        public void UpdateProduct(int index, Product updatedProduct)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }
            _products[index] = new Product(updatedProduct);
        }
        //Delete
        public void DeleteProduct(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }
            for (int i = index; i < _count - 1; i++)
            {
                _products[i] = _products[i + 1];
            }
            _products[_count - 1] = null;
            _count--;
        }
        public int GetTotalAmount()
        {
            int total = 0;
            for (int i = 0; i < _count; i++)
            {
                total += _products[i].Amount;
            }
            return total;
        }
        public decimal GetTotalValue()
        {
            decimal totalValue = 0;
            for (int i = 0; i < _count; i++)
            {
                totalValue += _products[i].TotalValue();
            }
            return totalValue;
        }
        public Product FindProduct(string name)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_products[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return new Product(_products[i]);
                }
            }
            return null;
        }
        public Product GetMostExpensiveProduct()
        {
            if (_count == 0)
            {
                return null;
            }
            Product max = _products[0];
            for (int i = 1; i < _count; i++)
            {
                if (_products[i].Price > max.Price)
                {
                    max = _products[i];
                }
            }
            return new Product(max);
        }
    }
}

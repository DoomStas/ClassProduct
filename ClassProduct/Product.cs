using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    public class Product
    {
        private string _name;                   // назва товару
        private CategoryTyp _category;               // категорія (тільки get)
        private decimal _price;                 // ціна
        private int _amount;                  // кількість

        private string[] _reviews;
        private int _reviewCount;

        //конструктор
        public Product(string name, CategoryTyp category, decimal price, int amount)
        {
            _name = name;
            _category = category;
            _price = price;
            _amount = amount;

            _reviews = new string[20];
            _reviewCount = 0;

        }
        //конструктор копіювання
        public Product(Product other)
        {
            _name = other._name;
            _category = other._category;
            _price = other._price;
            _amount = other._amount;

            _reviews = new string[other._reviews.Length];
            _reviewCount = other._reviewCount;

            for (int i = 0; i < other._reviewCount; i++)
            {
                _reviews[i] = other._reviews[i];
            }
        }

        //методи
        public void IncreaseAmount(int value)
        {
            if (value > 0)
            {
                _amount += value;
            }
        }
        public void DecreaseAmount(int value)
        {
            if (value > 0)
            {
                _amount -= value;
                if (_amount < 0)
                {
                    _amount = 0;
                }
            }
        }
        public decimal TotalValue()
        {
            return _price * _amount;
        }

        public void AddReview(string review)
        {
            if (_reviewCount >= _reviews.Length)
            {
                string[] tmp = new string[_reviews.Length * 2];
                for (int i = 0; i < _reviews.Length; i++)
                {
                    tmp[i] = _reviews[i];
                    _reviews = tmp;
                }
            }
            _reviews[_reviewCount] = review;
            _reviewCount++;
        }

        public string[] GetReviews()
        {
            string[] result = new string[_reviewCount];
            for (int i = 0; i < _reviewCount; i++)
            {
                result[i] = _reviews[i];
            }
            return result;
        }

        public bool UpdateReview(int index, string newReview)
        {
            if (index >= 0 && index < _reviewCount)
            {
                _reviews[index] = newReview;
                return true;
            }
            return false;
        }
        public bool DeleteReview(int index)
        {
            if (index >= 0 && index < _reviewCount)
            {
                for (int i = index; i < _reviewCount - 1; i++)
                {
                    _reviews[i] = _reviews[i + 1];
                }
                _reviews[_reviewCount - 1] = null;
                _reviewCount--;
                return true;
            }
            return false;
        }
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= _reviewCount)
                {
                    return "";
                }
                return _reviews[index];
            }
        }
        public string Name
        {
            get { return _name; }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public CategoryTyp Category
        {
            get { return _category; }
        }

        public virtual decimal GetPrice()
        {
            return _price;
        }
    }
}


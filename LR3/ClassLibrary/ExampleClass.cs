using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [System.Serializable()]

    public class ExampleClass
    {
        // Public, Protected, Private поля
        public int publicField;
        protected int protectedField;
        private int privateField;

        // Public, Protected, Private Свойства
        public int PublicProperty { get; set; }
        protected int ProtectedProperty { get; set; }
        private int PrivateProperty { get; set; }

        // Public, Protected, Private Методы
        public void PublicMethod()
        {
            Console.WriteLine("Public Method");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("Protected Method");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Private Method");
        }

        // Базовый конструктор
        public ExampleClass()
        {
            Console.WriteLine("Base Constructor");
        }

        // Конструктор с полями
        public ExampleClass(int publicField, int protectedField, int privateField)
        {
            this.publicField = publicField;
            this.protectedField = protectedField;
            this.privateField = privateField;
            Console.WriteLine("Constructor with Fields");
        }
    }
}


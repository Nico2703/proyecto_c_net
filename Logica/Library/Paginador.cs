using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class Paginador<T>
    {
        private List<T> _dataList;
        private Label _label;
        private static int max_Reg, _reg_por_pagina, pageCount, numPagi = 1;

        public Paginador(List<T> dataList, Label label, int reg_por_pagina)
        {
            _dataList = dataList;
            _label = label;
            _reg_por_pagina = reg_por_pagina;
            cargarDatos();
        }

        private void cargarDatos()
        {
            numPagi = 1;
            max_Reg = _dataList.Count;
            pageCount = (max_Reg / _reg_por_pagina);

            if((max_Reg % _reg_por_pagina) > 0)
            {
                pageCount += 1;
            }
            _label.Text = $"Páginas 1 / {pageCount}";
        }
        public int primero()
        {
            numPagi = 1;
            _label.Text = $"Páginas {numPagi} / {pageCount}";
            return numPagi;
        }
        public int anterior()
        {
            if (numPagi > 1)
            {
                numPagi -= 1;
                _label.Text = $"Páginas {numPagi} / {pageCount}";
            }
            return numPagi;
        }
        public int siguiente()
        {
            if (numPagi == pageCount)
                numPagi -= 1;
            if (numPagi < pageCount)
            {
                numPagi += 1;
                _label.Text = $"Páginas {numPagi} / {pageCount}";
            }
            return numPagi;
        }
        public int ultimo()
        {
            numPagi = pageCount;
            _label.Text = $"Páginas {numPagi} / {pageCount}";
            return numPagi;
        }
    }
}

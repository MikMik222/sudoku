using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Services.FileDialog
{
    public interface IOpenDialog
    {
        public string OpenDialogForOpen();
        public string OpenDialogForSave();
    }
}

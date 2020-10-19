using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.DAL
{
    public interface ICloudForImage
    {
        void Upload(string path);
        void Download(string name, string saveTo);
        void Rename(string newName, string oldName);
        void Remove(string name);
    }
}

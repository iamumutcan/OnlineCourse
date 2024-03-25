using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common;
public class FileCourseDocument
{
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public int Duration { get; set; }
    public double FileSize { get; set; }
    public string Error {  get; set; }
}

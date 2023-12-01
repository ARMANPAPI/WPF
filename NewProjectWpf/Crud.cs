using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProjectWpf
{
    public class Crud
    {
        db db1 = new db();

        public string Crete(human h)
        {
            try
            {
                if (h.Age >= 18)
                {
                    if (!Exist(h))
                    {
                        db1.humen.Add(h);
                        db1.SaveChanges();
                        return "کاربر با موفقیت ثبت شد";
                    }
                    else
                    {
                        return "کاربر قبلا در بانک اطلاعاتی ثبت شده است";
                    }
                }
                else
                {
                    return "کاربر به دلیل عدم مجوز سنی ثبت نمیشود";
                }
            }
            catch (Exception e)
            {
                return ("مشکل سرور رخ داده لطفا با طراح نرم افزار تماس حاصل فرمایید" + e.Message);

            }

        }


        public bool Exist(human h)
        {
            return db1.humen.Any(i => h.Name == i.Name);
        }


        public List<human> Read()
        {
            return db1.humen.ToList();
        }



        public List<human> Serch(string Filte, int index)
        {
            if (index == 1)
            {
                return db1.humen.Where(i => i.Name.Contains(Filte) || i.Family.Contains(Filte)).ToList();
            }
            else if(index == 2)
            {
                return db1.humen.Where(i => i.Name.Contains(Filte) || i.Family.Contains(Filte)).ToList();
            }
            return db1.humen.ToList();
        }


        public human ReadById(int id)
        {
            return db1.humen.Find(id);
        }


        public string Update(int id, human h)
        {
            human hh = ReadById(id);
            hh.Name = h.Name;
            hh.Family = h.Family;
            hh.Age = h.Age;
            db1.SaveChanges();
            return "oki";
        }


        public string Delete(int id)
        {
            
            human p = ReadById(id);
            db1.humen.Remove(p);
            db1.SaveChanges();
            return "مشتری مورد نظر حذف شد";
        }

    }
}

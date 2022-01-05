using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectAprozar.Data;

namespace ProiectAprozar.Models
{
    public class FructCategoriePageModel:PageModel
    {
        public List<CategorieData> CategorieDataList;
        public void PopulateAssignedCategorieData(ProiectAprozarContext context, Fruct fruct)
        {
            var allCategorii = context.Categorie;
            var fructCategorii = new HashSet<int>(fruct.FructCategorii.Select(c => c.CategorieID));
            CategorieDataList = new List<CategorieData>();
            foreach(var cat in allCategorii)
            {
                CategorieDataList.Add(new CategorieData
                 {
                    CategorieID = cat.ID,
                    Nume = cat.DenumireCategorie,
                    Assigned= fructCategorii.Contains(cat.ID)
                });

            }
        }
        public void UpdateFructCategorii(ProiectAprozarContext context, string[] selectedCategorii, Fruct fructToUpdate)
        {
            if(selectedCategorii == null)
            {
                fructToUpdate.FructCategorii = new List<FructCategorie>();
                return;
            }
            var selectedCategoriiHS = new HashSet<string>(selectedCategorii);
            var fructCategorii = new HashSet<int>(fructToUpdate.FructCategorii.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if (!fructCategorii.Contains(cat.ID))
                    {
                        fructToUpdate.FructCategorii.Add(
                            new FructCategorie
                            {
                                FructID = fructToUpdate.ID,
                                CategorieID = cat.ID
                            });
                    }
                }
                else
                {
                    if (fructCategorii.Contains(cat.ID))
                    {
                        FructCategorie courseToRemove
                            = fructToUpdate.FructCategorii.SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

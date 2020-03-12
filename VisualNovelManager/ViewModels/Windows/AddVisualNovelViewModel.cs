using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using VndbSharp;
using VisualNovelManager.Helpers.Vndb;
using VndbSharp.Models;
using VndbSharp.Models.VisualNovel;
using System.Threading;

namespace VisualNovelManager.ViewModels.Windows
{
    public class AddVisualNovelViewModel
    {
        public int VnId { get; set; }
        public string VnName { get; set; }
        public string ExePath { get; set; }
        public string IconPath { get; set; }


        private bool IsJapaneseText(string text)
        {
            Regex regex = new Regex(@"/[\u3000-\u303F]|[\u3040-\u309F]|[\u30A0-\u30FF]|[\uFF00-\uFFEF]|[\u4E00-\u9FAF]|[\u2605-\u2606]|[\u2190-\u2195]|\u203B/g");
            return regex.IsMatch(text);
        }


    }
    public class AddVnViewModelValidator: AbstractValidator<AddVisualNovelViewModel>
    {

        public AddVnViewModelValidator()
        {
            RuleFor(x => x.ExePath).Must(ValidateExe).WithMessage("Not a valid Executable");
            RuleFor(x => x.ExePath).NotEmpty().WithMessage("Path to application is required");
            RuleFor(x => x.VnId).GreaterThan(1).WithMessage("Vndb ID must be at least 1");
            RuleFor(x => x.VnId).NotEmpty().WithMessage("Vndb ID is required");


            RuleFor(x => x.VnId).MustAsync(IsNotAboveMaxId).WithMessage("Not a Valid Vndb ID"); //need to reverse this
            RuleFor(x => x.VnId).MustAsync(IsNotDeletedVn).WithMessage("This Vndb ID has been removed"); //need to reverse this

            RuleFor(x => x.ExePath).Must(EndsWithExe).WithMessage("Not a valid filepath");
            RuleFor(x => x.IconPath).Must(EndsWithIco).WithMessage("Not a valid filepath");
            RuleFor(x => x.VnId).Must(IsNotDuplicateVn).WithMessage("This Vndb ID already exists");

         }


        #region Validators
        private bool ValidateExe(string filepath)
        {
            try
            {
                if (!File.Exists(filepath)) return false;
                byte[] twoBytes = new byte[2];
                using (FileStream fileStream = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    fileStream.Read(twoBytes, 0, 2);
                }
                switch (Encoding.UTF8.GetString(twoBytes))
                {
                    case "MZ":
                        return true;
                    case "ZM":
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Globals.Logger.Error(ex, "Failed to validate executable", ex.Data);
                throw;
            }
        }

        private async Task<bool> IsNotAboveMaxId(int id, CancellationToken cancellation)
        {
            try
            {
                using (Vndb client = new Vndb(true))
                {
                    RequestOptions ro = new RequestOptions
                    {
                        Reverse = true,
                        Sort = "id",
                        Count = 1
                    };
                    VndbResponse<VisualNovel> response = await client.GetVisualNovelAsync(VndbFilters.Id.GreaterThan(1), VndbFlags.Basic, ro);
                    if (response != null)
                    {
                        if (id < response.Items[0].Id) return true;
                        else return false;
                    }
                    else
                    {
                        HandleError.HandleErrors(client.GetLastError(), 0);
                        return false; 
                    }
                }
            }
            catch (Exception ex)
            {
                Globals.Logger.Error(ex, "Could not check max vndb id", ex.Data);
                return false;
            }
        }

        private async Task<bool> IsNotDeletedVn(int inputid, CancellationToken cancellation)
        {
            try
            {
                using (Vndb client = new Vndb(true))
                {
                    uint vnid = Convert.ToUInt32(inputid);
                    VndbResponse<VisualNovel> response = await client.GetVisualNovelAsync(VndbFilters.Id.Equals(vnid));
                    if (response != null)
                    {
                        return response.Count > 0;
                    }
                    else
                    {
                        HandleError.HandleErrors(client.GetLastError(), 0);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Globals.Logger.Error(ex, "check for deleted vn failed");
                return false;
            }
        }

        private bool EndsWithExe(string path)
        {
            try
            {
                if (!File.Exists(path)) return false;
                string ext = Path.GetExtension(path).ToLower() ?? string.Empty;
                return ext.EndsWith(".exe");
            }
            catch (Exception ex)
            {
                Globals.Logger.Warning(ex, "EndsWithExe check failed");
                return false;
            }
        }

        private bool EndsWithIco(string path)
        {
            try
            {
                if (!File.Exists(path)) return false;
                string ext = Path.GetExtension(path).ToLower() ?? string.Empty;
                return ext.EndsWith(".ico");
            }
            catch (Exception ex)
            {
                Globals.Logger.Warning(ex, "EndsWithIco check failed");
                return false;
            }
        }

        private bool IsNotDuplicateVn(int id)
        {
            throw new NotImplementedException("Need to add support for LiteDB");
            //return context.VnInfo.Any(x => x.VnId.Equals(InputVnId));

        } 
        #endregion





    }
}

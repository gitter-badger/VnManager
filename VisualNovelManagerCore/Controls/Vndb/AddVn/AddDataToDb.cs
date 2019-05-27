﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VisualNovelManagerCore.Database.Model.VNDB.VnInfo;
using VndbSharp.Models;
using VndbSharp.Models.Common;
using VndbSharp.Models.VisualNovel;
using LiteDB;
using VisualNovelManagerCore.Database.Model.VNDB.VnCharacter;
using VisualNovelManagerCore.Database.Model.VNDB.VnRelease;
using VndbSharp.Models.Character;
using VndbSharp.Models.Release;

namespace VisualNovelManagerCore.Controls.Vndb.AddVn
{
    class AddDataToDb
    {
        private void AddToDb()
        {

        }

        private async Task AddVnInfo(VndbResponse<VisualNovel> visualNovels)
        {
            if (visualNovels.FirstOrDefault() != null)
            {
                VisualNovel visualNovel = visualNovels.FirstOrDefault();

                //info
                VnInfo dbInfo = new VnInfo()
                {
                    VnId = visualNovel.Id,
                    Title = visualNovel.Name,
                    Original = visualNovel.OriginalName,
                    Released = visualNovel.Released?.ToString() ?? null,
                    Languages = ConvertToCsv(visualNovel.Languages),
                    OriginalLanguages = ConvertToCsv(visualNovel.OriginalLanguages),
                    Platforms = ConvertToCsv(visualNovel.Platforms),
                    Aliases = ConvertToCsv(visualNovel.Aliases),
                    Length = visualNovel.Length?.ToString(),
                    Description = visualNovel.Description,
                    ImageLink = visualNovel.Image,
                    ImageNsfw = visualNovel.IsImageNsfw,
                    Popularity = visualNovel.Popularity,
                    Rating = visualNovel.Rating
                };

                //anime
                List<VnInfoAnime> vnAnime = new List<VnInfoAnime>();
                foreach (AnimeMetadata anime in visualNovel.Anime)
                {
                    vnAnime.Add(new VnInfoAnime()
                    {
                        VnId = visualNovel.Id,
                        AniDbId = anime.AniDbId,
                        AnnId = anime.AnimeNewsNetworkId,
                        AniNfoId = anime.AnimeNfoId,
                        TitleEng = anime.RomajiTitle,
                        TitleJpn = anime.KanjiTitle,
                        Year = anime.AiringYear?.ToString() ?? null,
                        AnimeType = anime.Type
                    });                   
                }

                //links
                VnInfoLinks vnLinks = new VnInfoLinks()
                {
                    VnId = visualNovel.Id,
                    Wikipedia = visualNovel.VisualNovelLinks.Wikipedia,
                    Encubed = visualNovel.VisualNovelLinks.Encubed,
                    Renai = visualNovel.VisualNovelLinks.Renai
                };

                //screenshots
                if (visualNovel.Screenshots.Count > 0)
                {
                    List<VnInfoScreens> vnScreenshots = new List<VnInfoScreens>();
                    foreach (ScreenshotMetadata screenshot in visualNovel.Screenshots)
                    {
                        vnScreenshots.Add(new VnInfoScreens()
                        {
                            VnId = visualNovel.Id,
                            ImageUrl = screenshot.Url,
                            ReleaseId = screenshot.ReleaseId,
                            Nsfw = screenshot.IsNsfw,
                            Height = screenshot.Height,
                            Width = screenshot.Width
                        });
                    }
                }

                //relations
                if (visualNovel.Relations.Count > 0)
                {
                    List<VnInfoRelations> vnRelations = new List<VnInfoRelations>();
                    foreach (VisualNovelRelation relation in visualNovel.Relations)
                    {
                        vnRelations.Add(new VnInfoRelations()
                        {
                            VnId = visualNovel.Id,
                            RelationId = relation.Id,
                            Relation = relation.Type.ToString(),
                            Title = relation.Title,
                            Original = relation.Original,
                            Official = relation.Official ? "Yes" : "No"
                        });
                    }
                }

                //staff
                if (visualNovel.Staff.Count > 0)
                {
                    List<VnInfoStaff> vnStaff = new List<VnInfoStaff>();
                    foreach (StaffMetadata staff in visualNovel.Staff)
                    {
                        vnStaff.Add(new VnInfoStaff()
                        {
                            VnId = visualNovel.Id,
                            StaffId = staff.StaffId,
                            AliasId = staff.AliasId,
                            Name = staff.Name,
                            Original = staff.Kanji,
                            Role = staff.Role,
                            Note = staff.Note
                        });
                    }
                }

            }
        }

        private async Task AddVnCharacters(List<Character> characters, uint vnid)
        {
            if (characters.Count > 0)
            {
                List<VnCharacterInfo> vnCharacters = new List<VnCharacterInfo>();
                List<VnCharacterVns> vnCharacterVns = new List<VnCharacterVns>();
                List<VnCharacterVoiced> vnCharacterVoices = new List<VnCharacterVoiced>();
                List<VnCharacterInstances> vnCharacterInstances = new List<VnCharacterInstances>();
                foreach (Character vncharacter in characters)
                {
                    VnCharacterInfo character = new VnCharacterInfo()
                    {
                        VnId = vnid,
                        CharacterId = vncharacter.Id,
                        Name = vncharacter.Name,
                        Original = vncharacter.OriginalName,
                        Gender = vncharacter.Gender.ToString(),
                        BloodType = vncharacter.BloodType.ToString(),
                        Birthday = ConvertBirthday(vncharacter.Birthday),
                        Aliases = ConvertToCsv(vncharacter.Aliases),
                        Description = vncharacter.Description,
                        ImageLink = vncharacter.Image,
                        Bust = Convert.ToInt32(vncharacter.Bust),
                        Waist = Convert.ToInt32(vncharacter.Waist),
                        Hip = Convert.ToInt32(vncharacter.Hip),
                        Height = Convert.ToInt32(vncharacter.Height),
                        Weight = Convert.ToInt32(vncharacter.Weight)
                    };

                    foreach (VndbSharp.Models.Character.VisualNovelMetadata vn in vncharacter.VisualNovels)
                    {
                        vnCharacterVns.Add(new VnCharacterVns()
                        {
                            CharacterId = vncharacter.Id,
                            VnId = vn.Id,
                            ReleaseId = vn.ReleaseId,
                            SpoilerLevel = (byte)vn.SpoilerLevel,
                            Role = vn.Role.ToString()
                        });
                    }

                    foreach (VoiceActorMetadata voice in vncharacter.VoiceActorMetadata)
                    {
                        vnCharacterVoices.Add(new VnCharacterVoiced()
                        {
                            StaffId = voice.StaffId,
                            StaffAliasId = voice.AliasId,
                            VnId = voice.VisualNovelId,
                            Note = voice.Note
                        });
                    }

                    foreach (CharacterInstances instance in vncharacter.CharacterInstances)
                    {
                        vnCharacterInstances.Add(new VnCharacterInstances()
                        {
                            CharacterId = character.Id,
                            Spoiler = (byte)instance.Spoiler,
                            Name = instance.Name,
                            Original = instance.Kanji
                        });
                    }
                }
            }
        }

        private async Task AddVnReleases(List<Release> vnReleases, uint vnid)
        {
            if (vnReleases.Count > 0)
            {
                List<VnRelease> vnRelease = new List<VnRelease>();
                List<VnReleaseMedia> vnReleaseMedia = new List<VnReleaseMedia>();
                List<VnReleaseProducers> vnReleaseProducers = new List<VnReleaseProducers>();
                List<VnReleaseVn> vnReleaseVns = new List<VnReleaseVn>();
                foreach (Release release in vnReleases)
                {
                    vnRelease.Add(new VnRelease()
                    {
                        ReleaseId = release.Id,
                        Title = release.Name,
                        Original = release.OriginalName,
                        ReleaseType = release.Type.ToString(),
                        Patch = release.IsPatch,
                        Freeware = release.IsFreeware,
                        Doujin = release.IsDoujin,
                        Languages = ConvertToCsv(release.Languages),
                        Website = release.Website,
                        Notes = release.Notes,
                        MinAge = Convert.ToByte(release.MinimumAge),
                        Gtin = release.Gtin,
                        Catalog = release.Catalog,
                        Platforms = ConvertToCsv(release.Platforms),
                        Resolution = release.Resolution,
                        Voiced = release.Voiced.ToString(),
                        Animation = string.Join(",", release.Animation)
                    });

                    if (release.Media.Count > 0)
                    {
                        foreach (Media media in release.Media)
                        {
                            vnReleaseMedia.Add(new VnReleaseMedia()
                            {
                                ReleaseId = release.Id,
                                Medium = media.Medium,
                                Quantity = media.Quantity
                            });
                        }
                    }

                    if (release.Producers.Count > 0)
                    {
                        foreach (ProducerRelease producer in release.Producers)
                        {
                            vnReleaseProducers.Add(new VnReleaseProducers()
                            {
                                ReleaseId = release.Id,
                                ProducerId = producer.Id,
                                Developer = producer.IsDeveloper,
                                Publisher = producer.IsPublisher,
                                Name = producer.Name,
                                Original = producer.OriginalName,
                                ProducerType = producer.ProducerType
                            });
                        }
                    }

                    if (release.VisualNovels.Count > 0)
                    {
                        foreach (VndbSharp.Models.Release.VisualNovelMetadata vn in release.VisualNovels)
                        {
                            vnReleaseVns.Add(new VnReleaseVn()
                            {
                                ReleaseId = vn.Id,
                                VnId = vnid,
                                Name = vn.Name,
                                Original = vn.OriginalName
                            });
                        }
                    }
                }
            }
        }

        private async Task GetDetailsFromTagDump(ReadOnlyCollection<TagMetadata> vnTags)
        {
            throw new NotImplementedException();
        }

        private async Task GetDetailsFromTraitDump(ReadOnlyCollection<TraitMetadata> traits, uint charId)
        {
            throw new NotImplementedException();
        }

        private string ConvertBirthday(SimpleDate birthday)
        {
            string formatted = string.Empty;
            if (birthday == null) return formatted;
            if (birthday.Month == null) return birthday.Month == null ? birthday.Day.ToString() : string.Empty;
            string month = System.Globalization.DateTimeFormatInfo.InvariantInfo.GetMonthName(Convert.ToInt32(birthday.Month));
            formatted = $"{month} {birthday.Day}";
            return formatted;
        }

        string ConvertToCsv(ReadOnlyCollection<string> input)
        {
            return input != null ? string.Join(",", input) : null;
        }
    }
}

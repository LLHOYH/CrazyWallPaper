﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using CrazyWallPaper.Models;
using CrazyWallPaper.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CrazyWallPaper.ViewModels
{
    public class WallPaperDetailsViewModel : BaseViewModel
    {
        string imgUrl;

        public WallPaperDetailsViewModel()
        {
            DownloadCommand = new Command(DownloadImage);
        }

        public string ImgUrl
        {
            get { return imgUrl; }
            set { SetProperty(ref imgUrl, value); }
        }

        Command downloadCommand;
        public Command DownloadCommand
        {
            get { return downloadCommand; }
            set { SetProperty(ref downloadCommand, value); }
        }

        public void DownloadImage()
        {
            IFileService fileSvc = DependencyService.Get<IFileService>();


            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(ImgUrl);
            //Stream stream = new MemoryStream(bytes);

            //var buffer = new byte[16 * 1024];
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    int read;
            //    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            //    {
            //        ms.Write(buffer, 0, read);
            //    }
            //}

            fileSvc.SaveImageFromByte(bytes, "img2.png");

            //fileSvc.SavePicture(DateTime.Now.ToString(), stream, "temp");

        }
    }
}
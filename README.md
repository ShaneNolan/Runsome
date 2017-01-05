# Runsome
A simple ransomware like application which explains to the user the dangers of ransomware and the basics of protecting themselves online.

## Features
- Duplication.
- AES Encryption/Decryption.
- Startup.
- Server/Client.
- Countdown.
- List of Encrypted files.
- Educational aspect.
- ~~Detect other drives.~~
- ~~Detect if virtual machine.~~
- ~~Improve Server Side.~~

## How it works
Runsome works by encrypting personal files with the following extensions:
```
.jpg, .jpeg, .raw, .tif, .gif, .png, .bmp, .3dm, .max, .accdb, .db, .dbf, .mdb, .pdb, .sql, .dwg, .dxf, .c, .cpp, .cs, .h, .php, .asp, .rb, .java, .jar, .class, .py, .js, .aaf, .aep, .aepx, .plb, .prel, .prproj, .aet, .ppj, .psd, .indd, .indl, .indt, .indb, .inx, .idml, .pmd, .xqx, .xqx, .ai, .eps, .ps, .svg, .swf, .fla, .as3, .as, .txt, .doc, .dot, .docx, .docm, .dotx, .dotm, .docb, .rtf, .wpd, .wps, .msg, .pdf, .xls, .xlt, .xlm, .xlsx, .xlsm, .xltx, .xltm, .xlsb, .xla, .xlam, .xll, .xlw, .ppt, .pot, .pps, .pptx, .pptm, .potx, .potm, .ppam, .ppsx, .ppsm, .sldx, .sldm, .wav, .mp3, .aif, .iff, .m3u, .m4u, .mid, .mpa, .wma, .ra, .avi, .mov, .mp4, .3gp, .mpeg, .3g2, .asf, .asx, .flv, .mpg, .wmv, .vob, .m3u8, .dat, .csv, .efx, .sdf, .vcf, .xml, .ses, .Qbw, .QBB, .QBM, .QBI, .QBR, .Cnt, .Des, .v30, .Qbo, .Ini, .Lgb, .Qwc, .Qbp, .Aif, .Qba, .Tlg, .Qbx, .Qby, .1pa, .Qpd, .Txt, .Set, .Iif, .Nd, .Rtp, .Tlg, .Wav, .Qsm, .Qss, .Qst, .Fx0, .Fx1, .Mx0, .FPx, .Fxr, .Fim, .ptb, .Ai, .Pfb, .Cgn, .Vsd, .Cdr, .Cmx, .Cpt, .Csl, .Cur, .Des, .Dsf, .Ds4, , .Drw, .Dwg.Eps, .Ps, .Prn, .Gif, .Pcd, .Pct, .Pcx, .Plt, .Rif, .Svg, .Swf, .Tga, .Tiff, .Psp, .Ttf, .Wpd, .Wpg, .Wi, .Raw, .Wmf, .Txt, .Cal, .Cpx, .Shw, .Clk, .Cdx, .Cdt, .Fpx, .Fmv, .Img, .Gem, .Xcf, .Pic, .Mac, .Met, .PP4, .Pp5, .Ppf, .Xls, .Xlsx, .Xlsm, .Ppt, .Nap, .Pat, .Ps, .Prn, .Sct, .Vsd, .wk3, .wk4, .XPM, .zip, .rar
```
Firstly Runsome displays a fake error message telling that the application requires a .NET framework.  
A key beginning with ENC is generated. Runsome is duplicate to the TEMP folder.  
The key that was generated is then used to encrypt the files with an AES algorithm.  
The key is uploaded to a server along with the users username, ip address and the time remaining (current time with a day added on).  
Runsome is added to the startup. Finally Runsome is displayed to the user and begins explaining.

The decryption key is received from the server by clicking on the two link article and clicking the Get My Decryption Key button.
Once the decryption process ends, Runsome removes itself from startup and terminates.

## Image Preview
![Runsome](http://i.imgur.com/WNE2aIi.png)

## Video Demonstration
[Video via Sendvid](https://sendvid.com/cmec6zw4?play=true).

## News Articles
[Article via BleepingComputer](https://www.bleepingcomputer.com/news/security/koolova-ransomware-decrypts-for-free-if-you-read-two-articles-about-ransomware/).  
[Article via TheHackerNews](http://thehackernews.com/2017/01/decrypt-ransomware-files.html).  


### Legal Warning
This is for educational purposes only. I am not responsible  for what you do. Do not use this program maliciously. Be nice. :smiley:

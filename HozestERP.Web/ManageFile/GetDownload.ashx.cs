using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFile
{
    /// <summary>
    /// GetDownload 的摘要说明
    /// </summary>
    public class GetDownload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string paramFileName = CommonHelper.QueryString("FilePath");
            if (paramFileName.ToString().Trim().Length <= 0)
            {
                context.Response.Clear();
                context.Response.Write(@"{success:'false'}");
                return;
            }
            string paramTrueFileName = CommonHelper.QueryString("Filename");
            int intStart = paramFileName.LastIndexOf("/") + 1;
            string paramSaveName = paramFileName.Substring(intStart, paramFileName.Length - intStart);

            context.Response.AppendHeader("Pragma", "public");
            context.Response.Expires = 0;
            context.Response.AppendHeader("Cache-Control", "must-revalidate, post-check=0, pre-check=0");
            context.Response.AppendHeader("Content-Type", "application/force-download");

            string paramFileType = paramSaveName.Substring(paramSaveName.LastIndexOf(".") + 1, paramSaveName.Length - paramSaveName.LastIndexOf(".") - 1);
            context.Response.ContentType = this.GetContenttype(paramFileType);

            context.Response.AppendHeader("Content-Type", "application/force-download");
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + (paramTrueFileName.Length > 0 ? paramTrueFileName : HttpUtility.UrlEncode(paramSaveName, System.Text.Encoding.UTF8)));
            context.Response.WriteFile(paramFileName);
        }



        private void returnError(HttpContext context, string message)
        {
            context.Response.Clear();
            context.Response.Write(message);
            context.Response.Flush();
        }

        private string GetContenttype(string paramFileType)
        {
            switch (paramFileType.ToString().Trim().ToLower())
            {
                case "ez":
                    return "application/andrew-inset";

                case "hqx":
                    return "application/mac-binhex40";

                case "cpt":
                    return "application/mac-compactpro";

                case "doc":
                    return "application/msword";

                case "bin":
                    return "application/octet-stream";

                case "dms":
                    return "application/octet-stream";

                case "lha":
                    return "application/octet-stream";

                case "lzh":
                    return "application/octet-stream";

                case "exe":
                    return "application/octet-stream";

                case "class":
                    return "application/octet-stream";

                case "so":
                    return "application/octet-stream";

                case "dll":
                    return "application/octet-stream";

                case "oda":
                    return "application/oda";

                case "pdf":
                    return "application/pdf";

                case "ai":
                    return "application/postscript";

                case "eps":
                    return "application/postscript";

                case "ps":
                    return "application/postscript";

                case "smi":
                    return "application/smil";

                case "smil":
                    return "application/smil";

                case "mif":
                    return "application/vnd.mif";

                case "xls":
                    return "application/vnd.ms-excel";

                case "ppt":
                    return "application/vnd.ms-powerpoint";

                case "wbxml":
                    return "application/vnd.wap.wbxml";

                case "wmlc":
                    return "application/vnd.wap.wmlc";

                case "wmlsc":
                    return "application/vnd.wap.wmlscriptc";

                case "bcpio":
                    return "application/x-bcpio";

                case "vcd":
                    return "application/x-cdlink";

                case "pgn":
                    return "application/x-chess-pgn";

                case "cpio":
                    return "application/x-cpio";

                case "csh":
                    return "application/x-csh";

                case "dcr":
                    return "application/x-director";

                case "dir":
                    return "application/x-director";

                case "dxr":
                    return "application/x-director";

                case "dvi":
                    return "application/x-dvi";

                case "spl":
                    return "application/x-futuresplash";

                case "gtar":
                    return "application/x-gtar";

                case "hdf":
                    return "application/x-hdf";

                case "js":
                    return "application/x-javascript";

                case "skp":
                    return "application/x-koan";

                case "skd":
                    return "application/x-koan";

                case "skt":
                    return "application/x-koan";

                case "skm":
                    return "application/x-koan";

                case "latex":
                    return "application/x-latex";

                case "nc":
                    return "application/x-netcdf";

                case "cdf":
                    return "application/x-netcdf";

                case "sh":
                    return "application/x-sh";

                case "shar":
                    return "application/x-shar";

                case "swf":
                    return "application/x-shockwave-flash";

                case "sit":
                    return "application/x-stuffit";

                case "sv4cpio":
                    return "application/x-sv4cpio";

                case "sv4crc":
                    return "application/x-sv4crc";

                case "tar":
                    return "application/x-tar";

                case "tcl":
                    return "application/x-tcl";

                case "tex":
                    return "application/x-tex";

                case "texinfo":
                    return "application/x-texinfo";

                case "texi":
                    return "application/x-texinfo";

                case "t":
                    return "application/x-troff";

                case "tr":
                    return "application/x-troff";

                case "roff":
                    return "application/x-troff";

                case "man":
                    return "application/x-troff-man";

                case "me":
                    return "application/x-troff-me";

                case "ms":
                    return "application/x-troff-ms";

                case "ustar":
                    return "application/x-ustar";

                case "src":
                    return "application/x-wais-source";

                case "xhtml":
                    return "application/xhtml+xml";

                case "xht":
                    return "application/xhtml+xml";

                case "zip":
                    return "application/zip";

                case "au":
                    return "audio/basic";

                case "snd":
                    return "audio/basic";

                case "mid":
                    return "audio/midi";

                case "midi":
                    return "audio/midi";

                case "kar":
                    return "audio/midi";

                case "mpga":
                    return "audio/mpeg";

                case "mp2":
                    return "audio/mpeg";

                case "mp3":
                    return "audio/mpeg";

                case "aif":
                    return "audio/x-aiff";

                case "aiff":
                    return "audio/x-aiff";

                case "aifc":
                    return "audio/x-aiff";

                case "m3u":
                    return "audio/x-mpegurl";

                case "ram":
                    return "audio/x-pn-realaudio";

                case "rm":
                    return "audio/x-pn-realaudio";

                case "rpm":
                    return "audio/x-pn-realaudio-plugin";

                case "ra":
                    return "audio/x-realaudio";

                case "wav":
                    return "audio/x-wav";

                case "pdb":
                    return "chemical/x-pdb";

                case "xyz":
                    return "chemical/x-xyz";

                case "bmp":
                    return "image/bmp";

                case "gif":
                    return "image/gif";

                case "ief":
                    return "image/ief";

                case "jpeg":
                    return "image/jpeg";

                case "jpg":
                    return "image/jpeg";

                case "jpe":
                    return "image/jpeg";

                case "png":
                    return "image/png";

                case "tiff":
                    return "image/tiff";

                case "tif":
                    return "image/tiff";

                case "djvu":
                    return "image/vnd.djvu";

                case "djv":
                    return "image/vnd.djvu";

                case "wbmp":
                    return "image/vnd.wap.wbmp";

                case "ras":
                    return "image/x-cmu-raster";

                case "pnm":
                    return "image/x-portable-anymap";

                case "pbm":
                    return "image/x-portable-bitmap";

                case "pgm":
                    return "image/x-portable-graymap";

                case "ppm":
                    return "image/x-portable-pixmap";

                case "rgb":
                    return "image/x-rgb";

                case "xbm":
                    return "image/x-xbitmap";

                case "xpm":
                    return "image/x-xpixmap";

                case "xwd":
                    return "image/x-xwindowdump";

                case "igs":
                    return "model/iges";

                case "iges":
                    return "model/iges";

                case "msh":
                    return "model/mesh";

                case "mesh":
                    return "model/mesh";

                case "silo":
                    return "model/mesh";

                case "wrl":
                    return "model/vrml";

                case "vrml":
                    return "model/vrml";

                case "css":
                    return "text/css";

                case "html":
                    return "text/html";

                case "htm":
                    return "text/html";

                case "asc":
                    return "text/plain";

                case "txt":
                    return "text/plain";

                case "rtx":
                    return "text/richtext";

                case "rtf":
                    return "text/rtf";

                case "sgml":
                    return "text/sgml";

                case "sgm":
                    return "text/sgml";

                case "tsv":
                    return "text/tab-separated-values";

                case "wml":
                    return "text/vnd.wap.wml";

                case "wmls":
                    return "text/vnd.wap.wmlscript";

                case "etx":
                    return "text/x-setext";

                case "xsl":
                    return "text/xml";

                case "xml":
                    return "text/xml";

                case "mpeg":
                    return "video/mpeg";

                case "mpg":
                    return "video/mpeg";

                case "mpe":
                    return "video/mpeg";

                case "qt":
                    return "video/quicktime";

                case "mov":
                    return "video/quicktime";

                case "mxu":
                    return "video/vnd.mpegurl";

                case "avi":
                    return "video/x-msvideo";

                case "movie":
                    return "video/x-sgi-movie";

                case "ice":
                    return "x-conference/x-cooltalk";

                default:
                    return "application/octet-stream";

            }
            // return "";
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
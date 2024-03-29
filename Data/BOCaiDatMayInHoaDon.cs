﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BOCaiDatMayInHoaDon
    {
        KaraokeEntities mKaraokeEntities = null;
        public BOCaiDatMayInHoaDon(Data.Transit transit)
        {
            mKaraokeEntities = new KaraokeEntities();
        }

        public static CAIDATMAYINHOADON GetQueryNoTracking(KaraokeEntities kara)
        {
            CAIDATMAYINHOADON item = FrameworkRepository<CAIDATMAYINHOADON>.QueryNoTracking(kara.CAIDATMAYINHOADONs).FirstOrDefault();
            if (item == null)
            {
                item = new CAIDATMAYINHOADON();
                item.HeaderTextString1 = "";
                item.HeaderTextString2 = "";
                item.HeaderTextString3 = "";
                item.HeaderTextString4 = "";
                item.HeaderTextFontSize1 = 12;
                item.HeaderTextFontSize2 = 12;
                item.HeaderTextFontSize3 = 12;
                item.HeaderTextFontSize4 = 12;
                item.HeaderTextFontStyle1 = (int)System.Drawing.FontStyle.Regular;
                item.HeaderTextFontStyle2 = (int)System.Drawing.FontStyle.Regular;
                item.HeaderTextFontStyle3 = (int)System.Drawing.FontStyle.Regular;
                item.HeaderTextFontStyle4 = (int)System.Drawing.FontStyle.Regular;
                item.HeaderTextFontWeights1 = (int)SomeEnum.FontWeights.Normal;
                item.HeaderTextFontWeights2 = (int)SomeEnum.FontWeights.Normal;
                item.HeaderTextFontWeights3 = (int)SomeEnum.FontWeights.Normal;
                item.HeaderTextFontWeights4 = (int)SomeEnum.FontWeights.Normal;

                item.FooterTextString1 = "";
                item.FooterTextString2 = "";
                item.FooterTextString3 = "";
                item.FooterTextString4 = "";
                item.FooterTextFontSize1 = 12;
                item.FooterTextFontSize2 = 12;
                item.FooterTextFontSize3 = 12;
                item.FooterTextFontSize4 = 12;
                item.FooterTextFontStyle1 = (int)System.Drawing.FontStyle.Regular;
                item.FooterTextFontStyle2 = (int)System.Drawing.FontStyle.Regular;
                item.FooterTextFontStyle3 = (int)System.Drawing.FontStyle.Regular;
                item.FooterTextFontStyle4 = (int)System.Drawing.FontStyle.Regular;
                item.FooterTextFontWeights1 = (int)SomeEnum.FontWeights.Normal;
                item.FooterTextFontWeights2 = (int)SomeEnum.FontWeights.Normal;
                item.FooterTextFontWeights3 = (int)SomeEnum.FontWeights.Normal;
                item.FooterTextFontWeights4 = (int)SomeEnum.FontWeights.Normal;

                item.SumanyFontSize = 12;
                item.SumanyFontStyle = (int)System.Drawing.FontStyle.Regular;
                item.SumanyFontWeights = (int)SomeEnum.FontWeights.Normal;
                item.SumanyFontSizeBig = 12;
                item.SumanyFontStyleBig = (int)System.Drawing.FontStyle.Regular;
                item.SumanyFontWeightsBig = (int)SomeEnum.FontWeights.Normal;
                item.TitleTextFontSize = 12;
                item.TitleTextFontStyle = (int)System.Drawing.FontStyle.Regular;
                item.TitleTextFontWeights = (int)SomeEnum.FontWeights.Normal;

            }
            return item;
        }

        public void Luu()
        {
            mKaraokeEntities.SaveChanges();
        }

        public CAIDATMAYINHOADON GetAll(Data.Transit transit)
        {
            CAIDATMAYINHOADON item = mKaraokeEntities.CAIDATMAYINHOADONs.FirstOrDefault();
            if (item == null)
            {
                item = new CAIDATMAYINHOADON();
                item.HeaderTextString1 = "";
                item.HeaderTextString2 = "";
                item.HeaderTextString3 = "";
                item.HeaderTextString4 = "";
                item.HeaderTextFontSize1 = 12;
                item.HeaderTextFontSize2 = 12;
                item.HeaderTextFontSize3 = 12;
                item.HeaderTextFontSize4 = 12;
                item.HeaderTextFontStyle1 = (int)SomeEnum.FontStyles.Normal;
                item.HeaderTextFontStyle2 = (int)SomeEnum.FontStyles.Normal;
                item.HeaderTextFontStyle3 = (int)SomeEnum.FontStyles.Normal;
                item.HeaderTextFontStyle4 = (int)SomeEnum.FontStyles.Normal;
                item.HeaderTextFontWeights1 = (int)SomeEnum.FontWeights.Normal;
                item.HeaderTextFontWeights2 = (int)SomeEnum.FontWeights.Normal;
                item.HeaderTextFontWeights3 = (int)SomeEnum.FontWeights.Normal;
                item.HeaderTextFontWeights4 = (int)SomeEnum.FontWeights.Normal;

                item.FooterTextString1 = "";
                item.FooterTextString2 = "";
                item.FooterTextString3 = "";
                item.FooterTextString4 = "";
                item.FooterTextFontSize1 = 12;
                item.FooterTextFontSize2 = 12;
                item.FooterTextFontSize3 = 12;
                item.FooterTextFontSize4 = 12;
                item.FooterTextFontStyle1 = (int)SomeEnum.FontStyles.Normal;
                item.FooterTextFontStyle2 = (int)SomeEnum.FontStyles.Normal;
                item.FooterTextFontStyle3 = (int)SomeEnum.FontStyles.Normal;
                item.FooterTextFontStyle4 = (int)SomeEnum.FontStyles.Normal;
                item.FooterTextFontWeights1 = (int)SomeEnum.FontWeights.Normal;
                item.FooterTextFontWeights2 = (int)SomeEnum.FontWeights.Normal;
                item.FooterTextFontWeights3 = (int)SomeEnum.FontWeights.Normal;
                item.FooterTextFontWeights4 = (int)SomeEnum.FontWeights.Normal;

                item.SumanyFontSize = 12;
                item.SumanyFontStyle = (int)SomeEnum.FontStyles.Normal;
                item.SumanyFontWeights = (int)SomeEnum.FontWeights.Normal;
                item.SumanyFontSizeBig = 12;
                item.SumanyFontStyleBig = (int)SomeEnum.FontStyles.Normal;
                item.SumanyFontWeightsBig = (int)SomeEnum.FontWeights.Normal;
                item.TitleTextFontSize = 12;
                item.TitleTextFontStyle = (int)SomeEnum.FontStyles.Normal;
                item.TitleTextFontWeights = (int)SomeEnum.FontWeights.Normal;
                mKaraokeEntities.CAIDATMAYINHOADONs.AddObject(item);
                mKaraokeEntities.SaveChanges();
            }

            return item;
        }
    }
}

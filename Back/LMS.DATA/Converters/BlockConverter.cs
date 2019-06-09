using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class BlockConverter
    {
        public static BlockDto Convert(Block item)
        {
            return new BlockDto
            {
                BlockTypeId = item.BlockTypeId,
                Id = item.Id,
                Img = item.Img,
                LoadImg = item.LoadImg,
                Name = item.Name,
                PageId = item.PageId,
                Text = item.Text
            };
        }

        public static Block Convert(BlockDto item)
        {
            return new Block
            {
                BlockTypeId = item.BlockTypeId,
                Id = item.Id,
                Img = item.Img,
                LoadImg = item.LoadImg,
                Name = item.Name,
                PageId = item.PageId,
                Text = item.Text
            };
        }

        public static List<Block> Convert(List<BlockDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<BlockDto> Convert(List<Block> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}

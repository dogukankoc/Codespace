using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System.Linq;

namespace SiteManagement.Services
{
    public class BlockService
    {
        readonly SiteManagementDbContext _context;
        public BlockService(SiteManagementDbContext context)
        {
            _context = context;
        }

        public void CreateBlock(CreateBlockDTO createBlockDTO, int siteId)
        {
            var block = new Block()
            {
                BlockName = createBlockDTO.Name,
                SiteId = siteId
            };
            _context.Blocks.Add(block);
            _context.SaveChanges();
        }

        public UpdateBlockDTO GetUpdateBlock(int siteId, int blockId)
        {
            var block = _context.Blocks
                    .Where(x => x.SiteId == siteId && x.Id == blockId)
                    .Select(x => new UpdateBlockDTO
                    {
                        BlockId = x.Id,
                        SiteId = x.SiteId,
                        BlockName = x.BlockName
                    }).FirstOrDefault();

            return block;
        }

        public int PostUpdateBlock(UpdateBlockDTO updateBlockDTO)
        {
            var toBeUpdatedBlock = _context.Blocks.FirstOrDefault(x => x.Id == updateBlockDTO.BlockId);
            toBeUpdatedBlock.BlockName = updateBlockDTO.BlockName;
            _context.SaveChanges();

            return toBeUpdatedBlock.SiteId;
        }

        public void DeleteBlock(int blockId)
        {
            var toBeDeletedBlock = _context.Blocks.FirstOrDefault(x => x.Id == blockId);
            _context.Blocks.Remove(toBeDeletedBlock);
            _context.SaveChanges();
        }
    }
}

﻿namespace WebApplication_Auction.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAllByUserName(string userName);
        Auction GetById(int id);

        void Add(Auction auction);
    }
}

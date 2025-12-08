using System;
using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class MemberRepository(AppDbContext appDbContext) : IMemberRepository
{
    public async Task<Member?> GetMemberByIdAsync(string id)
    {
        return await appDbContext.Members.FindAsync(id);
    }

    public async Task<IReadOnlyList<Member>> GetMembersAsync()
    {
        return await appDbContext.Members.ToListAsync();
    }

    public async Task<IReadOnlyList<Photo>> GetPhotosByMemberIdAsync(string memberId)
    {
        return await appDbContext.Members
        .Where(x => x.Id ==memberId)
        .SelectMany(x => x.Photos)
        .ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await appDbContext.SaveChangesAsync() > 0;
    }

    public void Update(Member member)
    {
        appDbContext.Entry(member).State = EntityState.Modified;
    }
}

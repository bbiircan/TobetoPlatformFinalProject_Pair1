﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Announcement;
using Business.Dtos.Responses.Announcement;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class AnnouncementManager : IAnnouncementService
{
    IMapper _mapper;
    IAnnouncementDal _announcementDal;

    public AnnouncementManager(IMapper mapper, IAnnouncementDal announcementDal)
    {
        _mapper = mapper;
        _announcementDal = announcementDal;
    }    
    public async Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest)
    {
        Announcement announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
        var createdAnnouncement = await _announcementDal.AddAsync(announcement);
        CreatedAnnouncementResponse createdAnnouncementResponse = _mapper.Map<CreatedAnnouncementResponse>(createdAnnouncement);
        return createdAnnouncementResponse;
    }

    public async Task<DeletedAnnouncementResponse> DeleteAsync(DeleteAnnouncementRequest deleteAnnouncementRequest)
    {
        Announcement announcement = await _announcementDal.GetAsync(a => a.Id == deleteAnnouncementRequest.Id);
        var deletedAnnouncement = await _announcementDal.DeleteAsync(announcement);
        DeletedAnnouncementResponse deletedAnnouncementResponse = _mapper.Map<DeletedAnnouncementResponse>(deletedAnnouncement);
        return deletedAnnouncementResponse; 
    }

    public async Task<GetAnnouncementResponse> GetByIdAsync(GetAnnouncementRequest getAnnouncementRequest)
    {
        var result = await _announcementDal.GetAsync(a => a.Id == getAnnouncementRequest.Id);
        return _mapper.Map<GetAnnouncementResponse>(result);
    }

    public async Task<IPaginate<GetListAnnouncementResponse>> GetListAsync(PageRequest pageRequest)
    {
        var result = await _announcementDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
        return _mapper.Map<Paginate<GetListAnnouncementResponse>>(result);
    }

    public async Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
    {
		Announcement announcement = await _announcementDal.GetAsync(a => a.Id == updateAnnouncementRequest.Id);
		_mapper.Map(updateAnnouncementRequest,announcement);
        var updatedAnnouncement = await _announcementDal.UpdateAsync(announcement);
        UpdatedAnnouncementResponse updatedAnnouncementResponse = _mapper.Map<UpdatedAnnouncementResponse>(updatedAnnouncement);
        return updatedAnnouncementResponse;
    }
}

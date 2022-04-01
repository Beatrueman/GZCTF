﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CTFServer.Models;

public class Game
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 比赛标题
    /// </summary>
    [Required]
    [MinLength(1, ErrorMessage = "题目过短")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 比赛描述
    /// </summary>
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// 比赛介绍
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 开始时间
    /// </summary>
    [Required]
    [JsonPropertyName("start")]
    public DateTimeOffset StartTimeUTC { get; set; } = DateTimeOffset.Parse("1970-01-01T00:00:00Z");

    /// <summary>
    /// 结束时间
    /// </summary>
    [Required]
    [JsonPropertyName("end")]
    public DateTimeOffset EndTimeUTC { get; set; } = DateTimeOffset.Parse("1970-01-01T00:00:00Z");

    #region Db Relationship
    /// <summary>
    /// 比赛通知
    /// </summary>
    [JsonIgnore]
    public List<Event> Events { get; set; } = new();

    /// <summary>
    /// 比赛题目
    /// </summary>
    [JsonIgnore]
    public List<Challenge> Challenges { get; set; } = new();

    /// <summary>
    /// 比赛提交
    /// </summary>
    [JsonIgnore]
    public List<Submission> Submissions { get; set; } = new();

    /// <summary>
    /// 比赛题目实例
    /// </summary>
    [JsonIgnore]
    public List<Instance> Instances { get; set; } = new();

    /// <summary>
    /// 比赛队伍
    /// </summary>
    [JsonIgnore]
    public List<Participation> Teams { get; set; } = new();
    #endregion Db Relationship
}
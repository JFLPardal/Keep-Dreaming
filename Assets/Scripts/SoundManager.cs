using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager {

  public const  string BALLOON_HIT = "balloon hit";
  public const string BALLOON_POP = "life lost";
  public const string WALL_HIT = "wall hit";
  public const string SPIDER_HIT = "spider hit";
  public const string SNAKE_HIT = "snake hit";
  public const string PROJECTILE_THROW = "projectile throw";
  public const string PROJECTILE_KICK = "projectile kick";
  public const string PROJECTILE_PICKUP = "projectile pickup";
  public const string BEAR_ATTACK = "bear attack";
  public const string ENEMIES_MOVE = "enemies move";
  public const string SPIDER_ATTACK = "spider attack";
  public const string SNAKE_ATTACK = "snake attack";

  private static AudioClip BalloonHit;
  private static AudioClip WallHit;
   private static AudioClip SpiderHit;
   private static AudioClip SnakeHit;
   private static AudioClip ProjectileThrow;
   private static AudioClip ProjectileKick;
   private static AudioClip ProjectilePickUp;
   private static AudioClip BearAttack;
   private static AudioClip EnemiesMove;
   private static AudioClip SpiderAttack;
   private static AudioClip SnakeAttack;
   private static AudioClip BalloonPop;

  private static AudioSource source;

  public static void SetUp()
  {
    AudioSource[] sources = GameObject.FindGameObjectWithTag("GameManager").GetComponents<AudioSource>();
    source = sources[0];
    BalloonHit = Resources.Load("SoundEffect/" + BALLOON_HIT, typeof(AudioClip)) as AudioClip;
    BalloonPop = Resources.Load("SoundEffect/" + BALLOON_POP, typeof(AudioClip)) as AudioClip;
    WallHit = Resources.Load("SoundEffect/" + WALL_HIT, typeof(AudioClip)) as AudioClip;
    SpiderHit = Resources.Load("SoundEffect/" + SPIDER_HIT, typeof(AudioClip)) as AudioClip;
    SnakeHit = Resources.Load("SoundEffect/" + SNAKE_HIT, typeof(AudioClip)) as AudioClip;
    ProjectileThrow = Resources.Load("SoundEffect/" + PROJECTILE_THROW, typeof(AudioClip)) as AudioClip;
    ProjectileKick = Resources.Load("SoundEffect/" + PROJECTILE_KICK, typeof(AudioClip)) as AudioClip;
    ProjectilePickUp = Resources.Load("SoundEffect/" + PROJECTILE_PICKUP, typeof(AudioClip)) as AudioClip;
    BearAttack = Resources.Load("SoundEffect/" + BEAR_ATTACK, typeof(AudioClip)) as AudioClip;
    EnemiesMove = Resources.Load("SoundEffect/" + ENEMIES_MOVE, typeof(AudioClip)) as AudioClip;
    SpiderAttack = Resources.Load("SoundEffect/" + SPIDER_ATTACK, typeof(AudioClip)) as AudioClip;
    SnakeAttack = Resources.Load("SoundEffect/" + SNAKE_ATTACK, typeof(AudioClip)) as AudioClip;
  }

  public static void PlaySound(string action)
  {
    AudioClip sound = null;
    switch (action)
    {
      case BALLOON_HIT:
        sound = BalloonHit;
        break;
      case BALLOON_POP:
        sound = BalloonPop;
        Debug.Log(sound);
        break;
      case WALL_HIT:
        sound = WallHit;
        break;
      case SPIDER_HIT:
        sound = SpiderHit;
        break;
      case SNAKE_HIT:
        sound = SnakeHit;
        break;
      case PROJECTILE_THROW:
        sound = ProjectileThrow;
        break;
      case PROJECTILE_KICK:
        sound = ProjectileKick;
        break;
      case PROJECTILE_PICKUP:
        sound = ProjectilePickUp;
        break;
      case BEAR_ATTACK:
        sound = BearAttack;
        break;
      case ENEMIES_MOVE:
        sound = EnemiesMove;
        break;
      case SPIDER_ATTACK:
        sound = SpiderAttack;
        break;
      case SNAKE_ATTACK:
        sound = SnakeAttack;
        break;
        
    }
    if (sound != null)
      source.PlayOneShot(sound,.5f);
  }

  public static void StopAudio()
  {
    source.Stop();
  }
}

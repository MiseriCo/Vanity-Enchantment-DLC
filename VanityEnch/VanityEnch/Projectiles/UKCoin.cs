using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace VanityEnch.Projectiles
{
    public class UKCoin : ModProjectile
    {
        public Microsoft.Xna.Framework.Vector2 defaultspeed;
        public int storeDamage;
        public float g;
        public int state;
        public bool IsPunched;
        public int DamageMod;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ULTRAKILL");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Projectile.damage = 0;
            Projectile.penetrate = -1;
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.DamageType = DamageClass.Default;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            state = 0;
            storeDamage = 0;
            IsPunched = false;
            DamageMod = 20;
            g = 0.1f;
            defaultspeed.X = 0;
            defaultspeed.Y = -8.0f;
            //Projectile.aiStyle = -1;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile cointarget = null;
            Projectile collision = null;
            NPC target = null;
            if (state == 0)
            {
                Projectile.ai[0]++;
                if (Projectile.ai[0] > 300)
                {
                    Projectile.Kill();
                }
                else if (Projectile.ai[0] >= 15)
                {
                    storeDamage += Projectile.damage;
                    Projectile.damage = 0;
                    foreach (var proj in Main.projectile)
                    {
                        if (Math.Abs(proj.position.X - Projectile.position.X) <= Math.Abs(proj.width + Projectile.width) &&
                            Math.Abs(proj.position.Y - Projectile.position.Y) <= Math.Abs(proj.height + Projectile.height) &&
                            proj.friendly && proj.damage > 0)
                        {
                            if (collision == null || proj.type == ModContent.ProjectileType<UKPunch>() || proj.type == ModContent.ProjectileType<UKCoin>() && collision.type != ModContent.ProjectileType<UKCoin>() && proj.damage > 0 || Microsoft.Xna.Framework.Vector2.Distance(Main.player[Main.myPlayer].position, proj.position) <
                                Vector2.Distance(Main.player[Main.myPlayer].position, proj.position))
                            {
                                collision = proj;
                            }
                        }
                        /*
                        else  if (proj.type == ModContent.ProjectileType<UKCoin>())
                        {
                            if (coin == null || Microsoft.Xna.Framework.Vector2.Distance(Main.player[Main.myPlayer].position, proj.position) <
                                Microsoft.Xna.Framework.Vector2.Distance(Main.player[Main.myPlayer].position, proj.position))
                            {
                                coin = proj;
                            }
                        }
                        */
                    }
                    Projectile.velocity.Y += g;
                    if (Projectile.velocity.Y >= 16.0f)
                    {
                        Projectile.velocity.Y = 16.0f;
                    }
                    if (collision != null)
                    {
                        if (collision.type == ModContent.ProjectileType<UKPunch>())
                        {
                            DamageMod += 20;
                            IsPunched = true;
                        }
                        Projectile.damage = DamageMod + collision.damage + storeDamage;
                        state = 1;
                        Projectile.velocity.X = 0;
                        Projectile.velocity.Y = 0;
                        collision.damage = 0;
                        collision.Kill();
                    }
                }
            }
            else if (state == 1)
            {
                foreach (Projectile proj in Main.projectile)
                {
                    if (proj.type == ModContent.ProjectileType<UKCoin>() && proj.damage == 0 && proj.active && proj.ai[0] >= 15)
                    {
                        cointarget = proj;
                    }
                }
                if (cointarget == null)
                {
                    foreach (NPC npc in Main.npc)
                    {
                        if (npc.life > 0 && !npc.friendly && (target == null || Main.player[Main.myPlayer].Distance(npc.position) < Main.player[Main.myPlayer].Distance(target.position)))
                        {
                            target = npc;
                        }
                    }
                }
                if (cointarget != null)
                {
                    Projectile.position = cointarget.position;
                    state = 2;
                }
                else if (target != null)
                {
                    Projectile.position = target.Center;
                    if (!IsPunched)
                    {
                        state = 2;
                    }
                    else
                    {
                        state = 3;
                        Projectile.ai[0] = 0;
                        Projectile.velocity = defaultspeed;
                        IsPunched = false;
                    }
                }
                else
                {
                    state = 2;
                }
            }
            else if (state == 2)
            {
                Projectile.damage = 0;
                Projectile.Kill();
            }
            else if (state == 3)
            {
                state = 0;
            }
            collision = null;
            target = null;
        }
        
        

        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.penetrate -= 1;
            if (Projectile.penetrate <= 0) {
                Projectile.Kill();
            }
        }
        */
    }
}
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System;

namespace VanityEnch.Projectiles
{
	public class UKPunch : ModProjectile
	{
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("+DISRESPECT");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Projectile.damage = 20;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.friendly = true;
            Projectile.knockBack = 2.0f;
            //Projectile.aiStyle = -1;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.ai[0] += 1;
            if (Projectile.ai[0] == 5) 
            {
                Projectile.Kill();
            }
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
using _Project.Data.Items;
using _Project.Source;
using _Project.Source.Dungeon.Battle;
using _Project.Source.Village.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This file is auto-generated. Do not modify manually.

public static class GameResources
{
    public static class Animation
    {
        public static class Monster
        {
        }
    }
    public static class Art
    {
        public static class GUI
        {
            public static class Panels
            {
                public static Texture2D ui => Resources.Load<Texture2D>("Art/GUI/Panels/ui");
                public static Texture2D ui_s => Resources.Load<Texture2D>("Art/GUI/Panels/ui_s");
                public static Texture2D ui_small_inset => Resources.Load<Texture2D>("Art/GUI/Panels/ui_small_inset");
                public static Texture2D ui_transparent => Resources.Load<Texture2D>("Art/GUI/Panels/ui_transparent");
                public static Texture2D ui_xs => Resources.Load<Texture2D>("Art/GUI/Panels/ui_xs");
                public static Texture2D ui_xxs => Resources.Load<Texture2D>("Art/GUI/Panels/ui_xxs");
                public static Texture2D ui_xxs_2x => Resources.Load<Texture2D>("Art/GUI/Panels/ui_xxs_2x");
                public static Texture2D ui_xxs_brighter => Resources.Load<Texture2D>("Art/GUI/Panels/ui_xxs_brighter");
            }
            public static Texture2D cursor => Resources.Load<Texture2D>("Art/GUI/cursor");
            public static Texture2D cursor2 => Resources.Load<Texture2D>("Art/GUI/cursor2");
            public static Texture2D line => Resources.Load<Texture2D>("Art/GUI/line");
        }
        public static class Icons
        {
            public static Texture2D _104361 => Resources.Load<Texture2D>("Art/Icons/104361");
            public static Texture2D captain => Resources.Load<Texture2D>("Art/Icons/captain");
            public static Texture2D charsheet_age => Resources.Load<Texture2D>("Art/Icons/charsheet_age");
            public static Texture2D charsheet_armor => Resources.Load<Texture2D>("Art/Icons/charsheet_armor");
            public static Texture2D charsheet_atk => Resources.Load<Texture2D>("Art/Icons/charsheet_atk");
            public static Texture2D charsheet_crit => Resources.Load<Texture2D>("Art/Icons/charsheet_crit");
            public static Texture2D charsheet_dmg_red => Resources.Load<Texture2D>("Art/Icons/charsheet_dmg_red");
            public static Texture2D charsheet_evasion => Resources.Load<Texture2D>("Art/Icons/charsheet_evasion");
            public static Texture2D charsheet_gold => Resources.Load<Texture2D>("Art/Icons/charsheet_gold");
            public static Texture2D charsheet_health => Resources.Load<Texture2D>("Art/Icons/charsheet_health");
            public static Texture2D charsheet_health1 => Resources.Load<Texture2D>("Art/Icons/charsheet_health1");
            public static Texture2D charsheet_health_regen => Resources.Load<Texture2D>("Art/Icons/charsheet_health_regen");
            public static Texture2D charsheet_hit => Resources.Load<Texture2D>("Art/Icons/charsheet_hit");
            public static Texture2D charsheet_ring => Resources.Load<Texture2D>("Art/Icons/charsheet_ring");
            public static Texture2D charsheet_weapon => Resources.Load<Texture2D>("Art/Icons/charsheet_weapon");
            public static Texture2D coins_sheet => Resources.Load<Texture2D>("Art/Icons/coins_sheet");
            public static Texture2D coins_sheet_s => Resources.Load<Texture2D>("Art/Icons/coins_sheet_s");
            public static Texture2D coins_sheet_s2 => Resources.Load<Texture2D>("Art/Icons/coins_sheet_s2");
            public static Texture2D gold_icon_x2 => Resources.Load<Texture2D>("Art/Icons/gold_icon_x2");
            public static Texture2D knight => Resources.Load<Texture2D>("Art/Icons/knight");
            public static Texture2D mender => Resources.Load<Texture2D>("Art/Icons/mender");
            public static Texture2D party_lead => Resources.Load<Texture2D>("Art/Icons/party_lead");
            public static Texture2D portrait_border => Resources.Load<Texture2D>("Art/Icons/portrait_border");
            public static Texture2D portrait_border_mask => Resources.Load<Texture2D>("Art/Icons/portrait_border_mask");
            public static Texture2D ranks_sheet => Resources.Load<Texture2D>("Art/Icons/ranks_sheet");
            public static Texture2D rank_a => Resources.Load<Texture2D>("Art/Icons/rank_a");
            public static Texture2D rank_a_backdrop => Resources.Load<Texture2D>("Art/Icons/rank_a_backdrop");
            public static Texture2D rank_a_small => Resources.Load<Texture2D>("Art/Icons/rank_a_small");
            public static Texture2D rank_b => Resources.Load<Texture2D>("Art/Icons/rank_b");
            public static Texture2D rank_backdrop => Resources.Load<Texture2D>("Art/Icons/rank_backdrop");
            public static Texture2D rank_b_backdrop => Resources.Load<Texture2D>("Art/Icons/rank_b_backdrop");
            public static Texture2D rank_b_small => Resources.Load<Texture2D>("Art/Icons/rank_b_small");
            public static Texture2D rank_c => Resources.Load<Texture2D>("Art/Icons/rank_c");
            public static Texture2D rank_c_backdrop => Resources.Load<Texture2D>("Art/Icons/rank_c_backdrop");
            public static Texture2D rank_c_small => Resources.Load<Texture2D>("Art/Icons/rank_c_small");
            public static Texture2D rank_d => Resources.Load<Texture2D>("Art/Icons/rank_d");
            public static Texture2D rank_d_backdrop => Resources.Load<Texture2D>("Art/Icons/rank_d_backdrop");
            public static Texture2D rank_d_small => Resources.Load<Texture2D>("Art/Icons/rank_d_small");
            public static Texture2D rank_e => Resources.Load<Texture2D>("Art/Icons/rank_e");
            public static Texture2D rank_e_backdrop => Resources.Load<Texture2D>("Art/Icons/rank_e_backdrop");
            public static Texture2D rank_e_small => Resources.Load<Texture2D>("Art/Icons/rank_e_small");
            public static Texture2D rank_s => Resources.Load<Texture2D>("Art/Icons/rank_s");
            public static Texture2D rank_s_backdrop => Resources.Load<Texture2D>("Art/Icons/rank_s_backdrop");
            public static Texture2D rank_s_small => Resources.Load<Texture2D>("Art/Icons/rank_s_small");
            public static Texture2D savant => Resources.Load<Texture2D>("Art/Icons/savant");
            public static Texture2D warden => Resources.Load<Texture2D>("Art/Icons/warden");
            public static Texture2D wildling => Resources.Load<Texture2D>("Art/Icons/wildling");
        }
        public static class Textures
        {
        }
    }
    public static class Balance
    {
    }
    public static class Fonts
    {
    }
    public static class Materials
    {
        public static class Fade_Patterns
        {
            public static Texture2D fade1 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade1");
            public static Texture2D fade10 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade10");
            public static Texture2D fade11 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade11");
            public static Texture2D fade12 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade12");
            public static Texture2D fade2 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade2");
            public static Texture2D fade3 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade3");
            public static Texture2D fade4 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade4");
            public static Texture2D fade5 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade5");
            public static Texture2D fade6 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade6");
            public static Texture2D fade7 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade7");
            public static Texture2D fade8 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade8");
            public static Texture2D fade9 => Resources.Load<Texture2D>("Materials/Fade Patterns/fade9");
        }
        public static class healer_textures
        {
            public static Texture2D mega_final_healer_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Materials/healer_textures/mega_final_healer_DefaultMaterial_AlbedoTransparency");
            public static Texture2D mega_final_healer_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Materials/healer_textures/mega_final_healer_DefaultMaterial_MetallicSmoothness");
            public static Texture2D mega_final_healer_DefaultMaterial_Normal => Resources.Load<Texture2D>("Materials/healer_textures/mega_final_healer_DefaultMaterial_Normal");
        }
        public static class Terrain
        {
            public static Material m_alchimic => Resources.Load<Material>("Materials/Terrain/m_alchimic");
            public static Material m_board => Resources.Load<Material>("Materials/Terrain/m_board");
            public static Material m_cave => Resources.Load<Material>("Materials/Terrain/m_cave");
            public static Material m_chest => Resources.Load<Material>("Materials/Terrain/m_chest");
            public static Material m_grass => Resources.Load<Material>("Materials/Terrain/m_grass");
            public static Material m_grave1 => Resources.Load<Material>("Materials/Terrain/m_grave1");
            public static Material m_grave2 => Resources.Load<Material>("Materials/Terrain/m_grave2");
            public static Material m_grave3 => Resources.Load<Material>("Materials/Terrain/m_grave3");
            public static Material m_grave4 => Resources.Load<Material>("Materials/Terrain/m_grave4");
            public static Material m_grave5 => Resources.Load<Material>("Materials/Terrain/m_grave5");
            public static Material m_horn => Resources.Load<Material>("Materials/Terrain/m_horn");
            public static Material m_rock1 => Resources.Load<Material>("Materials/Terrain/m_rock1");
            public static Material m_rock1_light => Resources.Load<Material>("Materials/Terrain/m_rock1_light");
            public static Material m_rock2 => Resources.Load<Material>("Materials/Terrain/m_rock2");
            public static Material m_rock3 => Resources.Load<Material>("Materials/Terrain/m_rock3");
            public static Material m_rock4 => Resources.Load<Material>("Materials/Terrain/m_rock4");
            public static Material m_rpg_objects => Resources.Load<Material>("Materials/Terrain/m_rpg_objects");
            public static Material m_smithy => Resources.Load<Material>("Materials/Terrain/m_smithy");
            public static Material m_tree => Resources.Load<Material>("Materials/Terrain/m_tree");
            public static Material rpgpp_lt_cloud_a => Resources.Load<Material>("Materials/Terrain/rpgpp_lt_cloud_a");
            public static Material rpgpp_lt_mat_a => Resources.Load<Material>("Materials/Terrain/rpgpp_lt_mat_a");
            public static Material rpgpp_lt_sky_a => Resources.Load<Material>("Materials/Terrain/rpgpp_lt_sky_a");
        }
        public static class Textures
        {
            public static Texture2D BG_dg1_1 => Resources.Load<Texture2D>("Materials/Textures/BG_dg1 1");
            public static Texture2D BG_dg2 => Resources.Load<Texture2D>("Materials/Textures/BG_dg2");
            public static Texture2D BG_dg3 => Resources.Load<Texture2D>("Materials/Textures/BG_dg3");
            public static Texture2D grass => Resources.Load<Texture2D>("Materials/Textures/grass");
            public static Texture2D grass1 => Resources.Load<Texture2D>("Materials/Textures/grass1");
            public static Texture2D grass2 => Resources.Load<Texture2D>("Materials/Textures/grass2");
            public static Texture2D grass3 => Resources.Load<Texture2D>("Materials/Textures/grass3");
            public static Texture2D ground1 => Resources.Load<Texture2D>("Materials/Textures/ground1");
            public static Texture2D ground2 => Resources.Load<Texture2D>("Materials/Textures/ground2");
            public static Texture2D ground3 => Resources.Load<Texture2D>("Materials/Textures/ground3");
            public static Texture2D ground4 => Resources.Load<Texture2D>("Materials/Textures/ground4");
            public static Texture2D ground5 => Resources.Load<Texture2D>("Materials/Textures/ground5");
            public static Texture2D ground7 => Resources.Load<Texture2D>("Materials/Textures/ground7");
        }
        public static Material healer_1 => Resources.Load<Material>("Materials/healer 1");
        public static Material Healer_Hair => Resources.Load<Material>("Materials/Healer Hair");
        public static Material Healer => Resources.Load<Material>("Materials/Healer");
        public static Material m_EnterDungeon => Resources.Load<Material>("Materials/m_EnterDungeon");
        public static Material m_Toon_Shader => Resources.Load<Material>("Materials/m_Toon Shader");
        public static Material m_ToonHair => Resources.Load<Material>("Materials/m_ToonHair");
        public static Material m_UnitHovered => Resources.Load<Material>("Materials/m_UnitHovered");
        public static Material Shader_Graphs_FadeOut => Resources.Load<Material>("Materials/Shader Graphs_FadeOut");
    }
    public static class Models
    {
        public static class alchimic
        {
            public static class texture
            {
                public static Texture2D alchimic_Material_001_AlbedoTransparency => Resources.Load<Texture2D>("Models/alchimic/texture/alchimic_Material.001_AlbedoTransparency");
                public static Texture2D alchimic_Material_001_MetallicSmoothness => Resources.Load<Texture2D>("Models/alchimic/texture/alchimic_Material.001_MetallicSmoothness");
                public static Texture2D alchimic_Material_001_Normal => Resources.Load<Texture2D>("Models/alchimic/texture/alchimic_Material.001_Normal");
            }
        }
        public static class board
        {
            public static class texture
            {
                public static Texture2D board_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/board/texture/board_DefaultMaterial_AlbedoTransparency");
                public static Texture2D board_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/board/texture/board_DefaultMaterial_MetallicSmoothness");
                public static Texture2D board_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/board/texture/board_DefaultMaterial_Normal");
            }
        }
        public static class cave
        {
            public static class pewera_texture
            {
                public static Texture2D pewera_full_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/cave/pewera_texture/pewera_full_DefaultMaterial_AlbedoTransparency");
                public static Texture2D pewera_full_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/cave/pewera_texture/pewera_full_DefaultMaterial_MetallicSmoothness");
                public static Texture2D pewera_full_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/cave/pewera_texture/pewera_full_DefaultMaterial_Normal");
            }
        }
        public static class chest
        {
            public static class texture
            {
                public static Texture2D chest_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/chest/texture/chest_DefaultMaterial_AlbedoTransparency");
                public static Texture2D chest_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/chest/texture/chest_DefaultMaterial_MetallicSmoothness");
                public static Texture2D chest_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/chest/texture/chest_DefaultMaterial_Normal");
            }
        }
        public static class graves
        {
            public static class gr1_textures
            {
                public static Texture2D mogila1_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/graves/gr1_textures/mogila1_DefaultMaterial_AlbedoTransparency");
                public static Texture2D mogila1_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/graves/gr1_textures/mogila1_DefaultMaterial_MetallicSmoothness");
                public static Texture2D mogila1_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/graves/gr1_textures/mogila1_DefaultMaterial_Normal");
            }
            public static class gr2_textures
            {
                public static Texture2D mogila2_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/graves/gr2_textures/mogila2_DefaultMaterial_AlbedoTransparency");
                public static Texture2D mogila2_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/graves/gr2_textures/mogila2_DefaultMaterial_MetallicSmoothness");
                public static Texture2D mogila2_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/graves/gr2_textures/mogila2_DefaultMaterial_Normal");
            }
            public static class gr3_textures
            {
                public static Texture2D mogila3_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/graves/gr3_textures/mogila3_DefaultMaterial_AlbedoTransparency");
                public static Texture2D mogila3_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/graves/gr3_textures/mogila3_DefaultMaterial_MetallicSmoothness");
                public static Texture2D mogila3_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/graves/gr3_textures/mogila3_DefaultMaterial_Normal");
            }
            public static class gr4_textures
            {
                public static Texture2D mogila4_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/graves/gr4_textures/mogila4_DefaultMaterial_AlbedoTransparency");
                public static Texture2D mogila4_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/graves/gr4_textures/mogila4_DefaultMaterial_MetallicSmoothness");
                public static Texture2D mogila4_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/graves/gr4_textures/mogila4_DefaultMaterial_Normal");
            }
            public static class gr5_textures
            {
                public static Texture2D mogila5_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/graves/gr5_textures/mogila5_DefaultMaterial_AlbedoTransparency");
                public static Texture2D mogila5_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/graves/gr5_textures/mogila5_DefaultMaterial_MetallicSmoothness");
                public static Texture2D mogila5_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/graves/gr5_textures/mogila5_DefaultMaterial_Normal");
            }
        }
        public static class horn
        {
            public static class textures
            {
                public static Texture2D gong_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/horn/textures/gong_DefaultMaterial_AlbedoTransparency");
                public static Texture2D gong_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/horn/textures/gong_DefaultMaterial_MetallicSmoothness");
                public static Texture2D gong_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/horn/textures/gong_DefaultMaterial_Normal");
            }
        }
        public static class low_poly_great_sword
        {
        }
        public static class Mixamo
        {
        }
        public static class Nature
        {
        }
        public static class Prefabs
        {
            public static GameObject alchimic => Resources.Load<GameObject>("Models/Prefabs/alchimic");
            public static GameObject board => Resources.Load<GameObject>("Models/Prefabs/board");
            public static GameObject box => Resources.Load<GameObject>("Models/Prefabs/box");
            public static GameObject cave_full => Resources.Load<GameObject>("Models/Prefabs/cave_full");
            public static GameObject chest => Resources.Load<GameObject>("Models/Prefabs/chest");
            public static GameObject flower1 => Resources.Load<GameObject>("Models/Prefabs/flower1");
            public static GameObject flower2 => Resources.Load<GameObject>("Models/Prefabs/flower2");
            public static GameObject flower3 => Resources.Load<GameObject>("Models/Prefabs/flower3");
            public static GameObject grass_small_01a => Resources.Load<GameObject>("Models/Prefabs/grass_small_01a");
            public static GameObject grass_small_01b => Resources.Load<GameObject>("Models/Prefabs/grass_small_01b");
            public static GameObject grave1 => Resources.Load<GameObject>("Models/Prefabs/grave1");
            public static GameObject grave2 => Resources.Load<GameObject>("Models/Prefabs/grave2");
            public static GameObject grave3 => Resources.Load<GameObject>("Models/Prefabs/grave3");
            public static GameObject grave4 => Resources.Load<GameObject>("Models/Prefabs/grave4");
            public static GameObject grave5 => Resources.Load<GameObject>("Models/Prefabs/grave5");
            public static GameObject hanger_wood => Resources.Load<GameObject>("Models/Prefabs/hanger_wood");
            public static GameObject horn => Resources.Load<GameObject>("Models/Prefabs/horn");
            public static GameObject smithy => Resources.Load<GameObject>("Models/Prefabs/smithy");
            public static GameObject tree => Resources.Load<GameObject>("Models/Prefabs/tree");
            public static GameObject wagon => Resources.Load<GameObject>("Models/Prefabs/wagon");
            public static GameObject well => Resources.Load<GameObject>("Models/Prefabs/well");
            public static GameObject wood => Resources.Load<GameObject>("Models/Prefabs/wood");
        }
        public static class Props
        {
        }
        public static class RPGPP_LT
        {
            public static class Models
            {
                public static class Nature
                {
                }
                public static class Props
                {
                }
                public static class Structures
                {
                }
            }
            public static class Prefabs
            {
                public static class Nature
                {
                    public static class Rocks
                    {
                        public static GameObject rpgpp_lt_rocks_tiny_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Rocks/rpgpp_lt_rocks_tiny_01");
                        public static GameObject rpgpp_lt_rock_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Rocks/rpgpp_lt_rock_01");
                        public static GameObject rpgpp_lt_rock_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Rocks/rpgpp_lt_rock_02");
                        public static GameObject rpgpp_lt_rock_03 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Rocks/rpgpp_lt_rock_03");
                        public static GameObject rpgpp_lt_rock_small_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Rocks/rpgpp_lt_rock_small_01");
                        public static GameObject rpgpp_lt_rock_small_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Rocks/rpgpp_lt_rock_small_02");
                    }
                    public static class Sky
                    {
                        public static GameObject rpgpp_lt_cloud_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Sky/rpgpp_lt_cloud_01");
                        public static GameObject rpgpp_lt_cloud_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Sky/rpgpp_lt_cloud_02");
                        public static GameObject rpgpp_lt_sky_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Sky/rpgpp_lt_sky_01");
                    }
                    public static class Terrain
                    {
                        public static GameObject rpgpp_lt_hill_small_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Terrain/rpgpp_lt_hill_small_01");
                        public static GameObject rpgpp_lt_hill_small_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Terrain/rpgpp_lt_hill_small_02");
                        public static GameObject rpgpp_lt_mountain_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Terrain/rpgpp_lt_mountain_01");
                        public static GameObject rpgpp_lt_terrain_grass_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Terrain/rpgpp_lt_terrain_grass_01");
                        public static GameObject rpgpp_lt_terrain_grass_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Terrain/rpgpp_lt_terrain_grass_02");
                        public static GameObject rpgpp_lt_terrain_path_01a => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Terrain/rpgpp_lt_terrain_path_01a");
                        public static GameObject rpgpp_lt_terrain_path_01b => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Terrain/rpgpp_lt_terrain_path_01b");
                        public static GameObject rpgpp_lt_terrain_sand_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Terrain/rpgpp_lt_terrain_sand_01");
                    }
                    public static class Vegetation
                    {
                        public static class Bushes
                        {
                            public static GameObject rpgpp_lt_bush_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Bushes/rpgpp_lt_bush_01");
                            public static GameObject rpgpp_lt_bush_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Bushes/rpgpp_lt_bush_02");
                        }
                        public static class Flowers
                        {
                            public static GameObject rpgpp_lt_flower_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Flowers/rpgpp_lt_flower_01");
                            public static GameObject rpgpp_lt_flower_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Flowers/rpgpp_lt_flower_02");
                            public static GameObject rpgpp_lt_flower_03 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Flowers/rpgpp_lt_flower_03");
                        }
                        public static class Grass
                        {
                            public static GameObject rpgpp_lt_grass_small_01a => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Grass/rpgpp_lt_grass_small_01a");
                            public static GameObject rpgpp_lt_grass_small_01b => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Grass/rpgpp_lt_grass_small_01b");
                        }
                        public static class Plants
                        {
                            public static GameObject rpgpp_lt_plant_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Plants/rpgpp_lt_plant_01");
                            public static GameObject rpgpp_lt_plant_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Plants/rpgpp_lt_plant_02");
                        }
                        public static class Trees
                        {
                            public static GameObject rpgpp_lt_tree_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Trees/rpgpp_lt_tree_01");
                            public static GameObject rpgpp_lt_tree_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Trees/rpgpp_lt_tree_02");
                            public static GameObject rpgpp_lt_tree_pine_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Nature/Vegetation/Trees/rpgpp_lt_tree_pine_01");
                        }
                    }
                }
                public static class Props
                {
                    public static class Containers
                    {
                        public static GameObject rpgpp_lt_barrel_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_barrel_01");
                        public static GameObject rpgpp_lt_bathtub_wood_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_bathtub_wood_01");
                        public static GameObject rpgpp_lt_bowl_metal_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_bowl_metal_01");
                        public static GameObject rpgpp_lt_box_wood_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_box_wood_01");
                        public static GameObject rpgpp_lt_bucket_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_bucket_01");
                        public static GameObject rpgpp_lt_jug_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_jug_01");
                        public static GameObject rpgpp_lt_package_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_package_01");
                        public static GameObject rpgpp_lt_sack_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_sack_01");
                        public static GameObject rpgpp_lt_sack_open_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_sack_open_01");
                        public static GameObject rpgpp_lt_trough_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_trough_01");
                        public static GameObject rpgpp_lt_vase_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_vase_01");
                        public static GameObject rpgpp_lt_vase_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Containers/rpgpp_lt_vase_02");
                    }
                    public static class Furniture
                    {
                        public static class Benches
                        {
                            public static GameObject rpgpp_lt_bench_wood_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Furniture/Benches/rpgpp_lt_bench_wood_01");
                        }
                        public static class Chairs
                        {
                            public static GameObject rpgpp_lt_chair_01a => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Furniture/Chairs/rpgpp_lt_chair_01a");
                            public static GameObject rpgpp_lt_chair_01b => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Furniture/Chairs/rpgpp_lt_chair_01b");
                        }
                        public static class Hangers
                        {
                            public static GameObject rpgpp_lt_hanger_clothes_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Furniture/Hangers/rpgpp_lt_hanger_clothes_01");
                            public static GameObject rpgpp_lt_hanger_wood_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Furniture/Hangers/rpgpp_lt_hanger_wood_01");
                        }
                        public static class Tables
                        {
                            public static GameObject rpgpp_lt_table_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Furniture/Tables/rpgpp_lt_table_01");
                        }
                    }
                    public static class Items
                    {
                        public static GameObject rpgpp_lt_broom_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Items/rpgpp_lt_broom_01");
                        public static GameObject rpgpp_lt_ladder_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Items/rpgpp_lt_ladder_01");
                        public static GameObject rpgpp_lt_rake_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Items/rpgpp_lt_rake_01");
                    }
                    public static class Misc
                    {
                        public static GameObject rpgpp_lt_bird_house_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Misc/rpgpp_lt_bird_house_01");
                        public static GameObject rpgpp_lt_wagon_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Misc/rpgpp_lt_wagon_01");
                        public static GameObject rpgpp_lt_well_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Misc/rpgpp_lt_well_01");
                    }
                    public static class Wall_decor
                    {
                        public static class Banners
                        {
                            public static GameObject rpgpp_lt_banner_01a => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Wall_decor/Banners/rpgpp_lt_banner_01a");
                            public static GameObject rpgpp_lt_banner_01b => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Wall_decor/Banners/rpgpp_lt_banner_01b");
                        }
                        public static class Shields
                        {
                            public static GameObject rpgpp_lt_shield_wall_01a => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Wall_decor/Shields/rpgpp_lt_shield_wall_01a");
                            public static GameObject rpgpp_lt_shield_wall_01b => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Wall_decor/Shields/rpgpp_lt_shield_wall_01b");
                        }
                    }
                    public static class Wood
                    {
                        public static GameObject rpgpp_lt_log_wood_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Props/Wood/rpgpp_lt_log_wood_01");
                    }
                }
                public static class Structures
                {
                    public static class Buildings
                    {
                        public static class Bld_closed
                        {
                            public static GameObject rpgpp_lt_building_01 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Structures/Buildings/Bld_closed/rpgpp_lt_building_01");
                            public static GameObject rpgpp_lt_building_02 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Structures/Buildings/Bld_closed/rpgpp_lt_building_02");
                            public static GameObject rpgpp_lt_building_03 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Structures/Buildings/Bld_closed/rpgpp_lt_building_03");
                            public static GameObject rpgpp_lt_building_04 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Structures/Buildings/Bld_closed/rpgpp_lt_building_04");
                            public static GameObject rpgpp_lt_building_05 => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Structures/Buildings/Bld_closed/rpgpp_lt_building_05");
                        }
                    }
                    public static class Parts
                    {
                        public static class Wood_path
                        {
                            public static GameObject rpgpp_lt_wood_path_01a => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Structures/Parts/Wood_path/rpgpp_lt_wood_path_01a");
                            public static GameObject rpgpp_lt_wood_path_01b => Resources.Load<GameObject>("Models/RPGPP_LT/Prefabs/Structures/Parts/Wood_path/rpgpp_lt_wood_path_01b");
                        }
                    }
                }
            }
            public static class Scene
            {
            }
            public static class Textures
            {
            }
        }
        public static class smithy
        {
            public static class textures
            {
                public static Texture2D smithy1_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/smithy/textures/smithy1_DefaultMaterial_AlbedoTransparency");
                public static Texture2D smithy1_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/smithy/textures/smithy1_DefaultMaterial_MetallicSmoothness");
                public static Texture2D smithy1_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/smithy/textures/smithy1_DefaultMaterial_Normal");
            }
        }
        public static class stones
        {
            public static class pewera_rock2_texture
            {
                public static Texture2D pewera_rock2_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/stones/pewera_rock2_texture/pewera_rock2_DefaultMaterial_AlbedoTransparency");
                public static Texture2D pewera_rock2_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/stones/pewera_rock2_texture/pewera_rock2_DefaultMaterial_MetallicSmoothness");
                public static Texture2D pewera_rock2_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/stones/pewera_rock2_texture/pewera_rock2_DefaultMaterial_Normal");
            }
            public static class pewera_rock3_texture
            {
                public static Texture2D pewera_rock3_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/stones/pewera_rock3_texture/pewera_rock3_DefaultMaterial_AlbedoTransparency");
                public static Texture2D pewera_rock3_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/stones/pewera_rock3_texture/pewera_rock3_DefaultMaterial_MetallicSmoothness");
                public static Texture2D pewera_rock3_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/stones/pewera_rock3_texture/pewera_rock3_DefaultMaterial_Normal");
            }
            public static class pewera_rock4_texture
            {
                public static Texture2D pewera_rock4_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/stones/pewera_rock4_texture/pewera_rock4_DefaultMaterial_AlbedoTransparency");
                public static Texture2D pewera_rock4_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/stones/pewera_rock4_texture/pewera_rock4_DefaultMaterial_MetallicSmoothness");
                public static Texture2D pewera_rock4_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/stones/pewera_rock4_texture/pewera_rock4_DefaultMaterial_Normal");
            }
            public static class rock1_textures
            {
                public static Texture2D rock1_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/stones/rock1_textures/rock1_DefaultMaterial_AlbedoTransparency");
                public static Texture2D rock1_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/stones/rock1_textures/rock1_DefaultMaterial_MetallicSmoothness");
                public static Texture2D rock1_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/stones/rock1_textures/rock1_DefaultMaterial_Normal");
            }
        }
        public static class Structures
        {
        }
        public static class tree
        {
            public static class tree_texture
            {
                public static Texture2D treePrefab_DefaultMaterial_AlbedoTransparency => Resources.Load<Texture2D>("Models/tree/tree_texture/treePrefab_DefaultMaterial_AlbedoTransparency");
                public static Texture2D treePrefab_DefaultMaterial_MetallicSmoothness => Resources.Load<Texture2D>("Models/tree/tree_texture/treePrefab_DefaultMaterial_MetallicSmoothness");
                public static Texture2D treePrefab_DefaultMaterial_Normal => Resources.Load<Texture2D>("Models/tree/tree_texture/treePrefab_DefaultMaterial_Normal");
            }
        }
        public static class weapons
        {
            public static Material cloth_soft => Resources.Load<Material>("Models/weapons/cloth_soft");
            public static Material gold => Resources.Load<Material>("Models/weapons/gold");
            public static Material leafs => Resources.Load<Material>("Models/weapons/leafs");
            public static Material Metal_1 => Resources.Load<Material>("Models/weapons/Metal 1");
            public static Material metal => Resources.Load<Material>("Models/weapons/metal");
            public static Material metal_light => Resources.Load<Material>("Models/weapons/metal_light");
            public static Material metal_lighter => Resources.Load<Material>("Models/weapons/metal_lighter");
            public static Material metal_light_shine => Resources.Load<Material>("Models/weapons/metal_light_shine");
            public static Material red => Resources.Load<Material>("Models/weapons/red");
            public static Material rock => Resources.Load<Material>("Models/weapons/rock");
            public static Material Shield => Resources.Load<Material>("Models/weapons/Shield");
            public static Material stone => Resources.Load<Material>("Models/weapons/stone");
            public static Material Vapp => Resources.Load<Material>("Models/weapons/Vapp");
            public static Material wood_dark => Resources.Load<Material>("Models/weapons/wood_dark");
            public static Material wood_inside => Resources.Load<Material>("Models/weapons/wood_inside");
            public static Material wood_light => Resources.Load<Material>("Models/weapons/wood_light");
            public static Material wood_normal => Resources.Load<Material>("Models/weapons/wood_normal");
        }
    }
    public static class Music
    {
    }
    public static class Prefabs
    {
        public static class Dungeon
        {
            public static GameObject DungeonPrefab__1_ => Resources.Load<GameObject>("Prefabs/Dungeon/DungeonPrefab (1)");
            public static GameObject DungeonPrefab__2_ => Resources.Load<GameObject>("Prefabs/Dungeon/DungeonPrefab (2)");
            public static GameObject DungeonPrefab__3_ => Resources.Load<GameObject>("Prefabs/Dungeon/DungeonPrefab (3)");
        }
        public static class Heroes
        {
            public static DungeonHero Barbarian => Resources.Load<DungeonHero>("Prefabs/Heroes/Barbarian");
            public static DungeonHero Captain => Resources.Load<DungeonHero>("Prefabs/Heroes/Captain");
            public static DungeonHero DungeonHero => Resources.Load<DungeonHero>("Prefabs/Heroes/DungeonHero");
            public static DungeonHero Healer => Resources.Load<DungeonHero>("Prefabs/Heroes/Healer");
            public static DungeonHero Mage => Resources.Load<DungeonHero>("Prefabs/Heroes/Mage");
            public static DungeonHero Ranger => Resources.Load<DungeonHero>("Prefabs/Heroes/Ranger");
            public static DungeonHero Tank => Resources.Load<DungeonHero>("Prefabs/Heroes/Tank");
        }
        public static class Monsters
        {
            public static DungeonMonster Beholder => Resources.Load<DungeonMonster>("Prefabs/Monsters/Beholder");
            public static DungeonMonster Brute => Resources.Load<DungeonMonster>("Prefabs/Monsters/Brute");
            public static DungeonMonster Demon => Resources.Load<DungeonMonster>("Prefabs/Monsters/Demon");
            public static DungeonMonster DungeonMonster => Resources.Load<DungeonMonster>("Prefabs/Monsters/DungeonMonster");
            public static DungeonMonster Mushroom => Resources.Load<DungeonMonster>("Prefabs/Monsters/Mushroom");
            public static DungeonMonster Skeleton => Resources.Load<DungeonMonster>("Prefabs/Monsters/Skeleton");
            public static DungeonMonster SkeletonArcher => Resources.Load<DungeonMonster>("Prefabs/Monsters/SkeletonArcher");
            public static DungeonMonster SkeletonKing => Resources.Load<DungeonMonster>("Prefabs/Monsters/SkeletonKing");
            public static DungeonMonster SkeletonMage => Resources.Load<DungeonMonster>("Prefabs/Monsters/SkeletonMage");
            public static DungeonMonster Succubus => Resources.Load<DungeonMonster>("Prefabs/Monsters/Succubus");
            public static DungeonMonster Wendigo => Resources.Load<DungeonMonster>("Prefabs/Monsters/Wendigo");
            public static DungeonMonster Wolf => Resources.Load<DungeonMonster>("Prefabs/Monsters/Wolf");
        }
        public static class UI
        {
            public static class Common
            {
                public static Image Button => Resources.Load<Image>("Prefabs/UI/Common/Button");
                public static Slider Progress_Bar => Resources.Load<Slider>("Prefabs/UI/Common/Progress Bar");
            }
            public static DungeonHUD Battle_HUD => Resources.Load<DungeonHUD>("Prefabs/UI/Battle HUD");
            public static UnitStatusHUD DungeonUnitHUD => Resources.Load<UnitStatusHUD>("Prefabs/UI/DungeonUnitHUD");
            public static ExpeditionSummary Expedition_Summary => Resources.Load<ExpeditionSummary>("Prefabs/UI/Expedition Summary");
            public static TextMeshProUGUI FloatingText => Resources.Load<TextMeshProUGUI>("Prefabs/UI/FloatingText");
            public static Image GoldView => Resources.Load<Image>("Prefabs/UI/GoldView");
            public static UnitPlate Hero_Plate_Big => Resources.Load<UnitPlate>("Prefabs/UI/Hero Plate Big");
            public static Image Hero_Small_Icon => Resources.Load<Image>("Prefabs/UI/Hero Small Icon");
            public static HeroExpeditionSummary Hero_Summary => Resources.Load<HeroExpeditionSummary>("Prefabs/UI/Hero Summary");
            public static UnitSelector HeroPicker => Resources.Load<UnitSelector>("Prefabs/UI/HeroPicker");
            public static GameObject Quest_Board => Resources.Load<GameObject>("Prefabs/UI/Quest Board");
            public static Image Recruit_Tooltip_Variant => Resources.Load<Image>("Prefabs/UI/Recruit Tooltip Variant");
            public static ContentSizeFitter Text_bubble => Resources.Load<ContentSizeFitter>("Prefabs/UI/Text bubble");
            public static UnitTooltipView Tooltip => Resources.Load<UnitTooltipView>("Prefabs/UI/Tooltip");
        }
        public static GameObject vfx_Healing => Resources.Load<GameObject>("Prefabs/vfx_Healing");
        public static VillageHero Village_Bers => Resources.Load<VillageHero>("Prefabs/Village Bers");
        public static VillageHero Village_Healer => Resources.Load<VillageHero>("Prefabs/Village Healer");
        public static VillageHero Village_Mage => Resources.Load<VillageHero>("Prefabs/Village Mage");
        public static VillageHero Village_Tank => Resources.Load<VillageHero>("Prefabs/Village Tank");
        public static VillageHero VillageHero_Scaled => Resources.Load<VillageHero>("Prefabs/VillageHero Scaled");
        public static VillageHero VillageHero => Resources.Load<VillageHero>("Prefabs/VillageHero");
    }
    public static class SFX
    {
    }
    public static class VFX
    {
        public static Texture2D Flare00 => Resources.Load<Texture2D>("VFX/Flare00");
        public static Material New_Material => Resources.Load<Material>("VFX/New Material");
        public static Texture2D uzor1 => Resources.Load<Texture2D>("VFX/uzor1");
        public static AutoDestroyVFX vfx_FireBall => Resources.Load<AutoDestroyVFX>("VFX/vfx_FireBall");
        public static AutoDestroyVFX vfx_Healing => Resources.Load<AutoDestroyVFX>("VFX/vfx_Healing");
        public static AutoDestroyVFX vfx_VerticalBeam => Resources.Load<AutoDestroyVFX>("VFX/vfx_VerticalBeam");
        public static AutoDestroyVFX vfx_VerticalBeam2 => Resources.Load<AutoDestroyVFX>("VFX/vfx_VerticalBeam2");
        public static Texture2D voronoi => Resources.Load<Texture2D>("VFX/voronoi");
    }
}

<template>
  <section class="container">
    <div class="row justify-content-center">
      <div class="col-md-6 col-lg-3 d-flex  theme-card theme-card-hover" v-for="r in recipe">
        <RecipeModal :recipe="activeRecipe" />
        <RecipeCard :recipe="r" :key="r.id" />

      </div>
    </div>
  </section>
</template>

<script>
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js"
import { onMounted } from "vue";
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
export default {
  setup() {
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      } catch (error) {
        Pop.error(error);
      }
    }



    onMounted(() => { getAllRecipes(); });

    return {
      recipe: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe),
      favrecipe: computed(() => AppState.favoriteRecipes),
      ingredients: computed(() => AppState.ingredients),
    };
  },

}
</script>

<style scoped lang="scss">
.text-shadow {
  color: rgb(121, 129, 34);
  text-shadow: 1px 1px rgb(88, 27, 27), 0px 0px 5px rgb(105, 41, 115);
  font-weight: bold;
  letter-spacing: 0.08rem
}
</style>

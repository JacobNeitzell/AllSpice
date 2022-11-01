<template>
  <section class="container">
    <div class="row">
      <div class="col-12">
        <RecipeCard :recipe="r" :key="r.id" />

      </div>
    </div>
  </section>
</template>

<script>
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js"
import { onMounted } from "vue";
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

    return {}
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>

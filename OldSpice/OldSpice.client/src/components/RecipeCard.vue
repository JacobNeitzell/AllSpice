<template>
  <div class="RecipeCard">
    <div class="card" style="width: 18rem;">
      <img class="card-img-top" :src="recipe?.img" :alt="recipe?.title" :title="recipe?.title + 'img'">
      <div class="card-body">
        <h5 class="card-title">Card title</h5>
        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's
          content.
        </p>
        <a href="#" class="btn btn-primary">Go somewhere</a>
      </div>
    </div>

  </div>
</template>


<script>
import { Recipe } from "../models/Recipe.js";

export default {
  props: {
    recipe: { type: Recipe, required: true },
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>
<template>
  <div class="flex justify-center items-center min-h-screen bg-gray-100">
    <div class="w-full max-w-xs">
      <form class="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
        <!-- Exercise Name -->
        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="exerciseName">Exercise Name</label>
          <input
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="exerciseName" type="text" v-model="exerciseName" placeholder="Enter exercise name" />
        </div>

        <!-- Sets -->
        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="sets">Sets</label>
          <input
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="sets" type="number" v-model="sets" placeholder="Enter sets" />
        </div>

        <!-- Reps -->
        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="reps">Reps</label>
          <input
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="reps" type="number" v-model="reps" placeholder="Enter reps" />
        </div>

        <!-- Weight -->
        <div class="mb-6">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="weight">Weight (kg)</label>
          <input
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="weight" type="number" v-model="weight" placeholder="Enter weight used" />
        </div>

        <!-- Submit Button -->
        <div class="flex items-center justify-between">
          <button
            class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            type="button" @click="submitForm">
            Log Exercise
          </button>
        </div>
      </form>
      <p class="text-center text-gray-500 text-xs">
        &copy;2024 Gains Before Grooms. All rights reserved.
      </p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      exerciseName: '',
      sets: '',
      reps: '',
      weight: '',
    };
  },
  methods: {
    submitForm() {
      console.log({
        exerciseName: this.exerciseName,
        sets: this.sets,
        reps: this.reps,
        weight: this.weight,
      });
      alert("Exercise logged successfully!");

      // Reset the form
      this.exerciseName = '';
      this.sets = '';
      this.reps = '';
      this.weight = '';
    },
  },
};
</script>

<style scoped>
/* Custom styles if needed */
</style>

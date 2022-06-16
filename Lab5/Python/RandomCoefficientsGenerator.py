import random


class RandSystem:
    @staticmethod
    def generate_random_system(size):
        lin_system = []
        for i in range(size):
            col = []
            for j in range(size + 1):
                col.append(random.randint(0, 20))
            lin_system.append(col)
        return lin_system

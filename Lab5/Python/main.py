from RandomCoefficientsGenerator import RandSystem
from ThreeVarSystem import ThreeSystemLinearEquation
from TwoVarSystem import TwoSystemLinearEquation
from Printer import SystemsPrinter

first_matrix = RandSystem.generate_random_system(2)
first_sys = TwoSystemLinearEquation(first_matrix)
SystemsPrinter.print_system(first_sys)
first_roots = first_sys.matrix_method()
SystemsPrinter.print_roots(first_roots)

second_matrix = RandSystem.generate_random_system(2)
second_sys = TwoSystemLinearEquation(second_matrix)
SystemsPrinter.print_system(second_sys)
second_roots = second_sys.kramer_method()
SystemsPrinter.print_roots(second_roots)

third_matrix = RandSystem.generate_random_system(3)
third_sys = ThreeSystemLinearEquation(third_matrix)
SystemsPrinter.print_system(third_sys)
third_roots = third_sys.matrix_method()
SystemsPrinter.print_roots(third_roots)

fourth_matrix = RandSystem.generate_random_system(3)
fourth_sys = ThreeSystemLinearEquation(fourth_matrix)
SystemsPrinter.print_system(fourth_sys)
fourth_roots = fourth_sys.matrix_method()
SystemsPrinter.print_roots(fourth_roots)

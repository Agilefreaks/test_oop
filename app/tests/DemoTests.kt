import org.junit.jupiter.api.Test
import kotlin.test.assertTrue

class DemoTests {
    @Test
    fun `demo pass test`() {
        assertTrue { true }
    }

    @Test
    fun `demo fail test`() {
        assertTrue { false }
    }
}